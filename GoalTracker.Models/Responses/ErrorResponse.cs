using GoalTracker.Models.Models;
using System.Collections.Generic;

namespace GoalTracker.Models.Responses
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
