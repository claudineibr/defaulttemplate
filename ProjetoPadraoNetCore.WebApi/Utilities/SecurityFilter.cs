using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjetoPadraoNetCore.Domain.Utilities;
using System;

namespace ProjetoPadraoNetCore.WebApi.Utilities
{
    public class SecurityFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var xApiKey = context.HttpContext.Request.Headers["x-api-key"];
            if (string.IsNullOrEmpty(xApiKey) || xApiKey != Config.ApiKey)
            {
                context.Result = new BadRequestObjectResult("Inválid API KEY");
                return;
            }

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
