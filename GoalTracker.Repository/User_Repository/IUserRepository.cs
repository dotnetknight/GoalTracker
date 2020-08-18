using GoalTracker.Domain.User;
using System.Threading.Tasks;

namespace GoalTracker.Repository.User_Repository
{
    public interface IUserRepository<T> where T : User
    {
        Task<T> Get(string email);
        Task Insert(T entity);
        Task UpdateMyProfile();
    }
}
