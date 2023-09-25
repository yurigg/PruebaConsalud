using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONSALUD.Prueba.WebAPI.AccessAuthorization
{
    public class ApiKeyAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiKeyAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }


    }
}
