using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Middelware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class DemoMiddleware
    {
        private readonly RequestDelegate _next;

        public DemoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class DemoMiddlewareExtensions
    {
        public static IApplicationBuilder UseDemoMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DemoMiddleware>();
        }
    }
}
