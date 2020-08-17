using GoalTracker.Domain.DailyTasks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoalTracker.Services.Task_service
{
    public interface ITaskService
    {
        Task AddTask(DailyTasks task);
        Task<IEnumerable<DailyTasks>> DailyTasks(string email);
        Task TaskDone(int taskId, bool done);
    }
}
