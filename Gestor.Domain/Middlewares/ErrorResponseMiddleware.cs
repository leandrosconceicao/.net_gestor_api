using Gestor.Domain.Entities;
using Gestor.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Data.Common;
using System.Net;
using System.Text.Json;

namespace Gestor.Domain.Middlewares
{
    public class ErrorResponseMiddleware : ErrorHandler
    {
        public ErrorResponseMiddleware(RequestDelegate requestDelegate) : base(requestDelegate)
        {
        }

        public override (HttpStatusCode code, string message) GetResponse(Exception exception)
        {
            HttpStatusCode code;
            string? stk = null;
            switch (exception)
            {
                case KeyNotFoundException
                    or NotFoundError
                    or FileNotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case UnauthorizedAccessException:
                    code = HttpStatusCode.Unauthorized;
                    break;
                case ArgumentException
                    or InvalidOperationException:
                    code = HttpStatusCode.BadRequest;
                    break;
                case DuplicateDataError:
                    code = HttpStatusCode.Conflict;
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    stk = exception.StackTrace;
                    break;
            }
            return (code, JsonSerializer.Serialize(new ErrorResponse
            {
                Result = false,
                Message = exception.Message,
                Tecnical = stk,
            }));
        }
    }
}
