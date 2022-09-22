using System.Net;
using System.Runtime.Serialization;

namespace CourseSchedule.Models.Exceptions
{
    [Serializable()]
    public class UnauthorizedException : AppException
    {
        public override HttpStatusCode HttpCode => HttpStatusCode.Unauthorized;
        public override string ErrorMessage => message;
        public string message = "Network credentials are no longer valid.";
        public UnauthorizedException() : base() { }
        public UnauthorizedException(string message) : base(message)
        {
            this.message = message;
        }
        public UnauthorizedException(string message, Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an exception propagates from a remoting server to the client. 
        protected UnauthorizedException(SerializationInfo info, StreamingContext context) { }
    }
}
