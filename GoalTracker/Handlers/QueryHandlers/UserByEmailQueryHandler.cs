using GoalTracker.Domain.User;
using GoalTracker.Repository.User_Repository;
using GoalTracker.Web.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GoalTracker.Web.Handlers.QueryHandlers
{
    public class UserByEmailQueryHandler : IRequestHandler<UserByEmailQuery, bool>
    {
        private IUserRepository<User> _userRepository;

        public UserByEmailQueryHandler(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UserByEmailQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.Get(request.Email);
            if (result == null)
                return false;

            return true;
        }
    }
}