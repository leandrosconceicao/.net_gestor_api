using Gestor.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Gestor.Domain.Middlewares
{
    public class ResponseMiddleware
    {
        private readonly RequestDelegate _next;
        public ResponseMiddleware(RequestDelegate next) { 
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;
            var stream = request.Body;
            var originalHeader = new StreamReader(stream);
            var originalContent = await originalHeader.ReadToEndAsync();

            
            await _next(context);
        }   
    }
}
