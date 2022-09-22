using System.Net;
using System.Runtime.Serialization;

namespace CourseSchedule.Models.Exceptions
{
    [Serializable()]
    public class ForbiddenException : AppException
    {
        public override HttpStatusCode HttpCode => HttpStatusCode.Forbidden;
        public override string ErrorMessage => message;
        public string message = "The incoming request was not valid";
        public ForbiddenException() : base() { }
        public ForbiddenException(string message) : base(message)
        {
            this.message = message;
        }
        public ForbiddenException(string message, Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an exception propagates from a remoting server to the client. 
        protected ForbiddenException(SerializationInfo info, StreamingContext context) { }
    }
}
