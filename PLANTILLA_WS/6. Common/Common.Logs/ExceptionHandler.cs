using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Common.Logs
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;
        private readonly ILogger _loggerFactory;
        public ExceptionHandler(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            _loggerFactory = loggerFactory.CreateLogger<ExceptionHandler>();
            loggerFactory.AddFile($"Logs/log.log");
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (HttpStatusCodeException StatusCodeEx)
            {
                await HandleExceptionAsync(context, StatusCodeEx);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, HttpStatusCodeException exception)
        {
            string result = null!;
            context.Response.ContentType = "application/json";
            if (exception is HttpStatusCodeException)
            {
                result = new ErrorDetails() { Message = exception.Message, StatusCode = (int)exception.StatusCode }.ToString();
                context.Response.StatusCode = (int)exception.StatusCode;
            }
            else
            {
                result = new ErrorDetails() { Message = exception.StackTrace!, StatusCode = (int)HttpStatusCode.InternalServerError }.ToString();
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            _loggerFactory.LogError($"{exception}");
            return context.Response.WriteAsync(result);
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string result = new ErrorDetails() { Message = exception.StackTrace!, StatusCode = (int)HttpStatusCode.InternalServerError }.ToString();
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            _loggerFactory.LogError($"{exception}");
            return context.Response.WriteAsync(result);
        }
    }
}
