using System.Text.Json;

namespace CourseSchedule.Models.Exceptions
{
    public class ErrorDetails
    {
        public int StatusCode { get; private set; }
        public string Message { get; private set; }

        public ErrorDetails(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
