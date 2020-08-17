using GoalTracker.Models.Responses;
using MediatR;

namespace GoalTracker.Web.Commands
{
    public class TaskDoneCommand : IRequest<TaskDoneResponse>
    {
        public int Id { get; set; }
        public bool Done { get; set; }
    }
}
