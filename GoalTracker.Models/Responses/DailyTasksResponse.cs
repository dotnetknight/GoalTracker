using GoalTracker.Domain.DailyTasks;
using System.Collections.Generic;

namespace GoalTracker.Models.Responses
{
    public class DailyTasksResponse : BaseResponse
    {
        public IEnumerable<DailyTasks> DailyTasks { get; set; }
    }
}