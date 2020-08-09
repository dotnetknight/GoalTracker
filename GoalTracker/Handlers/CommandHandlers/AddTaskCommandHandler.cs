using GoalTracker.Models.Responses;
using GoalTracker.Services.Task_service;
using GoalTracker.Web.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GoalTracker.Web.Handlers.CommandHandlers
{
    public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, AddTaskResponse>
    {
        private ITaskService _taskService;

        public AddTaskCommandHandler(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<AddTaskResponse> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            Domain.Task.Task taskEntity = new Domain.Task.Task
            {
                AddedDate = DateTime.UtcNow,
                Priority = request.Priority,
                TaskEndTime = request.TaskEndTime,
                TaskStartTime= request.TaskStartTime,
                Title = request.Title
            };

           await  _taskService.AddTask(taskEntity);

            return new AddTaskResponse
            {
                Message = "New task has successfully added"
            };
        }
    }
}
