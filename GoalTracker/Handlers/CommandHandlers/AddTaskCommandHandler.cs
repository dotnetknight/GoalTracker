using GoalTracker.Domain.DailyTasks;
using GoalTracker.Models.Responses;
using GoalTracker.Services.Task_service;
using GoalTracker.Web.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace GoalTracker.Web.Handlers.CommandHandlers
{
    public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, AddTaskResponse>
    {
        private ITaskService _taskService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AddTaskCommandHandler(ITaskService taskService, IHttpContextAccessor httpContextAccessor)
        {
            _taskService = taskService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AddTaskResponse> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            DailyTasks dailyTasks = new DailyTasks
            {
                AddedDate = DateTime.UtcNow,
                Priority = request.Priority,
                TaskEndTime = request.TaskEndTime,
                TaskStartTime = request.TaskStartTime,
                Title = request.Title,
                Owner = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value
            };

            await _taskService.AddTask(dailyTasks);

            return new AddTaskResponse
            {
                Message = "New task has successfully added"
            };
        }
    }
}
