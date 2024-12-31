namespace CarManagementApplication.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlerMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}