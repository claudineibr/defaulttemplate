using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NascorpLib.Cache.Redis;
using ProjetoPadraoNetCore.Domain.IApplicationService;
using ProjetoPadraoNetCore.Domain.Utilities;
using ProjetoPadraoNetCore.Domain.ViewModel;
using ProjetoPadraoNetCore.WebApi.Utilities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ProjetoPadraoNetCore.WebApi.Controllers
{
    [Authorize(Policy = "Bearer")]
    [SecurityFilter]
    public class ValuesController : ControllerBase
    {
        private readonly IMeuServicoApplicationService _meuServico;
        private readonly CacheExchange _cacheExchange;
        private readonly string _companyCode;
        private readonly string _personId;

        public ValuesController(IMeuServicoApplicationService _meuServico, CacheExchange cacheExchange, IHttpContextAccessor httpContextAccessor)
        {
            this._meuServico = _meuServico;
            this._cacheExchange = cacheExchange;
            this._companyCode = httpContextAccessor.CurrentCompanyCode();
            this._personId = httpContextAccessor.CurrentPersonId();
        }

        // GET api/values
        [HttpGet, Route("api/v1/values")]
        [ApiExplorerSettings(GroupName = "v1")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet, Route("api/v1/values/byid/{id}")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(typeof(MeuServicoViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.ExpectationFailed)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ByID(int id)
        {
            var cacheKey = $"Values/Values:ByID::{id}";
            MeuServicoViewModel responseCache = null;
            try
            {
                responseCache = this._cacheExchange.CacheGet<MeuServicoViewModel>(cacheKey);

                if (_cacheExchange.CheckIfCacheNeedsRenew(responseCache))
                {
                    var response = await this._meuServico.GetMeuServico(id);
                    responseCache = response;

                    if (NascorpLib.Utilities.IsNotEmpty(responseCache))
                    {
                        this._cacheExchange.CacheSet(cacheKey, response);
                    }
                }
               
                return Ok(responseCache);
            }
            catch (Exception ex)
            {
               // logger.Error($"Product/Products:ByID::{id}::{ex.Message}::{ex.InnerException}::{ex.StackTrace}::{ex.Data}");
                return StatusCode((int)HttpStatusCode.ExpectationFailed, ExceptionErrors.Extract(ex));
            }
        }
    }
}
