using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace TaskList.Api
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private static ILogger _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this.next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //log.Error(exception.Message + exception.InnerException);
            _logger.LogError(exception.Message + exception.InnerException + exception.StackTrace);
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            var exceptionType = exception.GetType();
            if (exceptionType == typeof(NotImplementedException)) code = HttpStatusCode.NotImplemented;
            else if (exceptionType == typeof(UnauthorizedAccessException)) code = HttpStatusCode.Unauthorized;
            else code = HttpStatusCode.BadRequest;
            //else if (exception is MyException) code = HttpStatusCode.BadRequest;

            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
        private void get()
        {

        }
    }
}
