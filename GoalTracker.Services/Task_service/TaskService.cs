using GoalTracker.Repository.Task_Repository;
using Microsoft.Extensions.Configuration;

namespace GoalTracker.Services.Task_service
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository<Domain.Task.Task> taskRepository;
        public IConfiguration _configuration;

        public TaskService(ITaskRepository<Domain.Task.Task> taskRepository, IConfiguration configuration)
        {
            this.taskRepository = taskRepository;
            _configuration = configuration;
        }

        public async System.Threading.Tasks.Task AddTask(Domain.Task.Task taskEntity)
        {
            await taskRepository.Insert(taskEntity);
        }
    }
}
