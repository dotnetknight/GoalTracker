using GoalTracker.Domain.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoalTracker.Services.User_Service
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        Task SignUp(User user);
        Task<User> SingleUser(string email);
        Task<string> AuthenticationToken(string email, string password);
        string PasswordHash(string password);
    }
}
