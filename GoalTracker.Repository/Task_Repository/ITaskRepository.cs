using System.Collections.Generic;

namespace GoalTracker.Repository.Task_Repository
{
    public interface ITaskRepository<T> where T : Domain.Task.Task
    {
        IEnumerable<T> GetAll();
        System.Threading.Tasks.Task Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
