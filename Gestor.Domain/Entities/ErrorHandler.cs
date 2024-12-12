using Microsoft.AspNetCore.Http;
using System.Net;
using Newtonsoft.Json;

namespace Gestor.Domain.Entities
{
    public abstract class ErrorHandler
    {
        private readonly RequestDelegate _requestDelegate;

        public abstract (HttpStatusCode code, string message) GetResponse(Exception exception);

        public ErrorHandler(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
                if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
                    SendResponse(context, StatusCodes.Status403Forbidden, "Acesso não permitido");
            }
            catch (Exception e)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var (status, message) = GetResponse(e);
                response.StatusCode = (int)status;
                await response.WriteAsync(message);
            }
        }

        private void SendResponse(HttpContext context, int statusCode, string message)
        {
            context.Response.Clear();
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            var response = new {
                description = message,
                result = false,
                returnDate = DateTime.UtcNow,
            };
            context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
