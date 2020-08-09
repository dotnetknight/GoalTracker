using System.Threading.Tasks;

namespace GoalTracker.Services.Task_service
{
    public interface ITaskService
    {
        Task AddTask(Domain.Task.Task Task);
    }
}
