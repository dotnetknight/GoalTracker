using GoalTracker.Models.ViewModels;
using MediatR;

namespace GoalTracker.Web.Queries
{
    public class MyProfileQuery : IRequest<MyProfileViewModel>
    {
    }
}
