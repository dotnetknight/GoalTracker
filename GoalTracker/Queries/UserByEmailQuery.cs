using MediatR;

namespace GoalTracker.Web.Queries
{
    public class UserByEmailQuery : IRequest<bool>
    {
        public string Email { get; }

        public UserByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
