using System.Net;
using System.Runtime.Serialization;

namespace CourseSchedule.Models.Exceptions
{
    [Serializable()]
    public class BadRequestException : AppException
    {
        public override HttpStatusCode HttpCode => HttpStatusCode.BadRequest;
        public override string ErrorMessage => message;
        public string message = "The incoming request was not valid.";
        public BadRequestException() : base() { }
        public BadRequestException(string message) : base(message)
        {
            this.message = message;
        }
        public BadRequestException(string message, Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an exception propagates from a remoting server to the client. 
        protected BadRequestException(SerializationInfo info, StreamingContext context) { }
    }
}
