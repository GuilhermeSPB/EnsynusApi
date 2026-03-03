using EnsynusApi.Exceptions;
using System.Net;
using System.Text.Json;

namespace EnsynusApi.Middleware
{
    public class ExceptionMiddleware
    {

        private readonly RequestDelegate _next;


        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
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
            HttpStatusCode status;
            string errorCode;

            switch (exception)
            {
                case EmailNaoConfirmadoException:
                    status = HttpStatusCode.Forbidden;
                    errorCode = "EMAIL_NOT_CONFIRMED";
                    break;

                case CredenciaisInvalidasException:
                    status = HttpStatusCode.Unauthorized;
                    errorCode = "INVALID_CREDENTIALS";
                    break;

                default:
                    status = HttpStatusCode.InternalServerError;
                    errorCode = "INTERNAL_SERVER_ERROR";
                    break;
            }

            var response = new
            {
                status = (int)status,
                errorCode = errorCode,
                message = exception.Message
            };

            var json = JsonSerializer.Serialize(response);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(json);

        }
    }
}
