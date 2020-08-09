using GoalTracker.Models.Responses;
using MediatR;

namespace GoalTracker.Web.Queries
{
    public class DailyTasksPerUserQuery : IRequest<DailyTasksResponse>
    {
    }
}
