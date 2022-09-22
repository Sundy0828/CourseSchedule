using System.Globalization;
using System.Net;
using System.Runtime.Serialization;

namespace CourseSchedule.Models.Exceptions
{
    [Serializable()]
    public abstract class AppException : Exception
    {
        public abstract HttpStatusCode HttpCode { get; }
        public abstract string ErrorMessage { get; }
        public AppException() : base() { }
        public AppException(string message) : base(message) { }
        public AppException(string message, Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an exception propagates from a remoting server to the client. 
        protected AppException(SerializationInfo info, StreamingContext context) { }
    }
}
