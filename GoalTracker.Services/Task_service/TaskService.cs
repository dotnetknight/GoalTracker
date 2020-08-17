using GoalTracker.Domain.DailyTasks;
using GoalTracker.Models.Exceptions;
using GoalTracker.Repository.Task_Repository;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GoalTracker.Services.Task_service
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository<DailyTasks> _taskRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TaskService(ITaskRepository<DailyTasks> taskRepository, IHttpContextAccessor httpContextAccessor)
        {
            _taskRepository = taskRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddTask(DailyTasks dailyTasks)
        {
            await _taskRepository.Insert(dailyTasks);
        }

        public async Task<IEnumerable<DailyTasks>> DailyTasks(string email)
        {
            return await _taskRepository.DailyTasks(email);
        }

        public async Task TaskDone(int taskId, bool done)
        {
            var userTasks = await _taskRepository.DailyTasks(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value);
            
            if (userTasks == null)
                throw new BaseApiException(System.Net.HttpStatusCode.NotFound, "For today, no tasks were found for this user.");

            var taskById = await _taskRepository.TaskById(taskId);
            
            if (taskById == null)
                throw new BaseApiException(System.Net.HttpStatusCode.NotFound, "Task with this id not found.");

            taskById.Done = done;

            await _taskRepository.UpdateTaskDone();
        }
    }
}