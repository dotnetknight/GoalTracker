using System;
using System.Net;

namespace GoalTracker.Models.Exceptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string APIMessage { get; protected set; }

        public ApiException(HttpStatusCode statusCode, string message)
        {
            APIMessage = message;
            StatusCode = statusCode;
        }
    }
}
