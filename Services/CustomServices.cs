using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yol.Services
{
    public static class CustomServices
    {
        private static string _baseUrl;

        public static string GetBaseUrl()
        {
            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var request = httpContextAccessor.HttpContext.Request;

            _baseUrl = $"{request.Scheme}://{request.Host}{request.PathBase}";

            return _baseUrl;
        }
    }
}
