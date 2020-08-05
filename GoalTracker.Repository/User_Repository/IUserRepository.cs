using GoalTracker.Domain.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoalTracker.Repository.User_Repository
{
    public interface IUserRepository<T> where T : User
    {
        IEnumerable<T> GetAll();
        Task<T> Get(string email);
        Task Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
