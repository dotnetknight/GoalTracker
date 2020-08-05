using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace GoalTracker.Models.Exceptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public ApiException(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
        }

        public ApiException(HttpStatusCode statusCode, string message) : base(message)
        {
            this.StatusCode = statusCode;
        }

        public ApiException(HttpStatusCode statusCode, Exception inner) : this(statusCode, inner.ToString()) { }

        public ApiException(HttpStatusCode statusCode, JObject errorObject) : this(statusCode, errorObject.ToString()) { }
    }
}
