using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NascorpLib;
using ProjetoPadraoNetCore.Domain;
using ProjetoPadraoNetCore.Domain.IApplicationService;
using ProjetoPadraoNetCore.Domain.Utilities;
using ProjetoPadraoNetCore.Domain.ViewModel;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ProjetoPadraoNetCore.WebApi.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ILoginApplication _loginApplication;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(ILoginApplication loginApplication,
                                        ILogger<AuthenticationController> logger)
        {
            _loginApplication = loginApplication;
            _logger = logger;
        }

        [HttpPost, Route("api/v1/authentication")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(typeof(LoginViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.ExpectationFailed)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Authentication([FromBody] AuthenticationViewModel entity)
        {
            BaseResponse<LoginViewModel> response = null;
            try
            {
                if (entity is null)
                    return StatusCode((int)HttpStatusCode.BadRequest, ExceptionErrors.Extract(new Exception(Constants.DATANOTFOUND), Domain.Utilities.ErrorStatusCode.NullData));

                if (!ModelState.IsValid)
                    return StatusCode((int)HttpStatusCode.BadRequest, ModelErrors.Extract(ModelState));

                response = new BaseResponse<LoginViewModel>
                {
                    Data = await _loginApplication.Authentication(entity),
                    Sucess = true
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                if (response is null) response = new BaseResponse<LoginViewModel>();
                response.Sucess = false;
                response.Errors = ExceptionErrors.Extract(ex);
                _logger.LogError($"Authentication::{ex.Message}::{ex.InnerException}::{ex.StackTrace}::{ex.Data}");
                return StatusCode((int)HttpStatusCode.BadRequest, response);
            }
        }

        [HttpGet, Route("api/v1/AuthenticationService")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(typeof(LoginViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.ExpectationFailed)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> AuthenticationService([FromHeader] string keyAuthentication)
        {
            BaseResponse<LoginViewModel> response = null;
            try
            {
                if (!ModelState.IsValid)
                    return StatusCode((int)HttpStatusCode.BadRequest, ModelErrors.Extract(ModelState));

                response = new BaseResponse<LoginViewModel>
                {
                    Data = await _loginApplication.AuthenticationService(keyAuthentication),
                    Sucess = true
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                if (response is null) response = new BaseResponse<LoginViewModel>();
                response.Sucess = false;
                response.Errors = ExceptionErrors.Extract(ex);
                _logger.LogError($"AuthenticationService::{ex.Message}::{ex.InnerException}::{ex.StackTrace}::{ex.Data}");
                return StatusCode((int)HttpStatusCode.BadRequest, response);
            }
        }
    }
}