using GoalTracker.Models.Responses;
using MediatR;

namespace GoalTracker.Web.Commands
{
    public class UserRegistrationCommand : IRequest<Response>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
