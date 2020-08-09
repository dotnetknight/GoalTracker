using GoalTracker.Models.Responses;
using MediatR;

namespace GoalTracker.Web.Commands
{
    public class AddTaskCommand : IRequest<AddTaskResponse>
    {
        public string Title { get; set; }
        public int Priority { get; set; }
        public string TaskStartTime { get; set; }
        public string TaskEndTime { get; set; }
    }
}
