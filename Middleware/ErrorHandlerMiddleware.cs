using System.Net;
using System.Text.Json;

namespace CarManagementApplication.Middleware
{
    public class ErrorHandlerMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
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
            var response = context.Response;
            response.ContentType = "application/json";

            var statusCode = exception switch
            {
                KeyNotFoundException => HttpStatusCode.NotFound,
                ApplicationException => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            };

            response.StatusCode = (int)statusCode;
            var result = JsonSerializer.Serialize(new { message = exception.Message });
            return response.WriteAsync(result);
        }
    }
}