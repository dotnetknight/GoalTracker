using GoalTracker.Domain.DailyTasks;
using GoalTracker.Repository.Task_Repository;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoalTracker.Services.Task_service
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository<DailyTasks> _taskRepository;
        public IConfiguration _configuration;

        public TaskService(ITaskRepository<DailyTasks> taskRepository, IConfiguration configuration)
        {
            _taskRepository = taskRepository;
            _configuration = configuration;
        }

        public async Task AddTask(DailyTasks dailyTasks)
        {
            await _taskRepository.Insert(dailyTasks);
        }

        public async Task<IEnumerable<DailyTasks>> DailyTasks(string email)
        {
            return await _taskRepository.DailyTasksByEmail(email);
        }
    }
}
