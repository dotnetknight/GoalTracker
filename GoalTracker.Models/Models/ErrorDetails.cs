using Newtonsoft.Json;
using System.Net;

namespace GoalTracker.Models.Models
{
    public class ErrorDetails
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
