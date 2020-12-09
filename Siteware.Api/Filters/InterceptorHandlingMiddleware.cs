using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Siteware.Api.Filters
{
    public class InterceptorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public InterceptorHandlingMiddleware(RequestDelegate next)
        {
            this._next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode code;
            var message = exception.Message;

            if (exception is ArgumentException)
            {
                code = HttpStatusCode.BadRequest;

            }
            else
            {
                code = HttpStatusCode.InternalServerError;
            }

            var result = JsonConvert.SerializeObject(new Error { Status = (int)code, Message = message });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
