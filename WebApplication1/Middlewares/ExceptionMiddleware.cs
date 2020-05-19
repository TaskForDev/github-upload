using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Services.Exceptions;
using SOLID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Services.Middlewares
{
    public class ExceptionMiddleware
    {

        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
          
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            
            if (!(exception is BaseException))
            {
                var customErrorDetails = exception.InnerException;
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsync(JsonConvert.SerializeObject(customErrorDetails));
            }
            else
            {
                BaseException baseException = exception as BaseException;
                CustomErrorDetails customErrorDetails = null;
                context.Response.ContentType = "application/json";
                var statuscode = GetCustomErrorCode(baseException, out customErrorDetails);
                context.Response.StatusCode = statuscode;
                return context.Response.WriteAsync(JsonConvert.SerializeObject(customErrorDetails));
            }
        }


        private int GetCustomErrorCode(BaseException baseException, out CustomErrorDetails customErrorDetails)
        {
            customErrorDetails = baseException.customErrorDetails;
            switch (baseException)
            {
                case BaseException b when (b.statuscode == HttpStatusCode.Forbidden):
                    customErrorDetails.errorcode = CustomErrorCode.InvalidRequest;
                    return (int)CustomErrorCode.InvalidRequest;
                default:
                    return (int)baseException.statuscode;
            }
        }

    }
}
