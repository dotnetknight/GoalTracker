using GoalTracker.Domain.DailyTasks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoalTracker.Repository.Task_Repository
{
    public interface ITaskRepository<T> where T : DailyTasks
    {
        Task<IEnumerable<DailyTasks>> DailyTasks(string email);
        Task Insert(T entity);
        Task UpdateTaskDone();
        Task<DailyTasks> TaskById(int taskId);
    }
}
