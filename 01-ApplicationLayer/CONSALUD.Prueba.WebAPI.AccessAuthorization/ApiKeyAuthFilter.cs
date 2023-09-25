using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using IAuthorizationFilter = Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter;

namespace CONSALUD.Prueba.WebAPI.AccessAuthorization
{
    public class ApiKeyAuthFilter: IAuthorizationFilter
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;

        public ApiKeyAuthFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(!context.HttpContext.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName, out
                var extratedApiKey))
            {
                context.Result = new UnauthorizedObjectResult("API Key missing");
                return;
            }

            var apiKey = _configuration.GetSection(AuthConstants.ApiKeySectionName);
            if (apiKey.Value.ToString() !=  extratedApiKey.ToString())
            {
                context.Result = new UnauthorizedObjectResult("Invalid API Key");
                return;
            }

        }
    }
}
