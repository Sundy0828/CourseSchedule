using System.Net;
using System.Runtime.Serialization;

namespace CourseSchedule.Models.Exceptions
{
    [Serializable()]
    public class NotFoundException : AppException
    {
        public override HttpStatusCode HttpCode => HttpStatusCode.NotFound;
        public override string ErrorMessage => message;
        public string message = "Unable to locate requested resource.";
        public NotFoundException() : base() { }
        public NotFoundException(string message) : base(message)
        {
            this.message = message;
        }
        public NotFoundException(string message, Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an exception propagates from a remoting server to the client. 
        protected NotFoundException(SerializationInfo info, StreamingContext context) { }
    }
}
