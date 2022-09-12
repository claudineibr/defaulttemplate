using Microsoft.AspNetCore.Http;
using ProjetoPadraoNetCore.Domain.Utilities;

namespace ProjetoPadraoNetCore.WebApi.Utilities
{
    public static class IHttpContextAccessorExtension
    {
        public static string CurrentCompanyCode(this IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor?.HttpContext?.User?.FindFirst(PersonalRegisteredClaimNames.CompanyId)?.Value;
        }

        public static string CurrentPersonId(this IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor?.HttpContext?.User?.FindFirst(PersonalRegisteredClaimNames.PersonId)?.Value;
        }

        public static string CurrentPersonName(this IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor?.HttpContext?.User?.FindFirst(PersonalRegisteredClaimNames.PersonName)?.Value;
        }
    }
}
