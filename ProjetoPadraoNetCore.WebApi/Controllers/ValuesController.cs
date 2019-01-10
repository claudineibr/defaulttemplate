using Microsoft.AspNetCore.Mvc;
using NascorpLib.Cache.Redis;
using NLog;
using ProjetoPadraoNetCore.Domain.IApplicationService;
using ProjetoPadraoNetCore.Domain.Utilities;
using ProjetoPadraoNetCore.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ProjetoPadraoNetCore.WebApi.Controllers
{
    public class ValuesController : Controller
    {
        private readonly IMeuServicoApplicationService _meuServico;
        private readonly CacheExchange _cacheExchange;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public ValuesController(IMeuServicoApplicationService _meuServico, CacheExchange cacheExchange)
        {
            this._meuServico = _meuServico;
            this._cacheExchange = cacheExchange;
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
            var cacheKey = $"Product/Products:ByID::{id}";
            MeuServicoViewModel responseCache = null;
            try
            {
                responseCache = this._cacheExchange.CacheGet<MeuServicoViewModel>(cacheKey);

                if (_cacheExchange.CheckIfCacheNeedsRenew(responseCache))
                {
                    var response = await this._meuServico.GetMeuServico(id);
                    responseCache = response;

                    if (Util.IsNotEmpty(responseCache))
                    {
                        this._cacheExchange.CacheSet(cacheKey, response);
                    }
                }

                return Ok(responseCache);
            }
            catch (Exception ex)
            {
                logger.Error($"Product/Products:ByID::{id}::{ex.Message}::{ex.InnerException}::{ex.StackTrace}::{ex.Data}");
                return StatusCode((int)HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }
    }
}
