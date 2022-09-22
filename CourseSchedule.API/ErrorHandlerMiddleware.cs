using System.Net;
using System.Text.Json;
using CourseSchedule.Models.Exceptions;

namespace CourseSchedule.API
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                string message = "";

                switch (error)
                {
                    case AppException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        message = e.Message;
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        message = e.Message;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        message = "Internal Server Error";
                        break;
                }

                var result = JsonSerializer.Serialize(new ErrorDetails((int)response.StatusCode, message ));
                await response.WriteAsync(result);
            }
        }
    }
}
