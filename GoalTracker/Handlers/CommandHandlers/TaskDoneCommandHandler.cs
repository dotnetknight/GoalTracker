using GoalTracker.Models.Responses;
using GoalTracker.Services.Task_service;
using GoalTracker.Web.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GoalTracker.Web.Handlers.CommandHandlers
{
    public class TaskDoneCommandHandler : IRequestHandler<TaskDoneCommand, TaskDoneResponse>
    {
        private ITaskService _taskService;

        public TaskDoneCommandHandler(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<TaskDoneResponse> Handle(TaskDoneCommand request, CancellationToken cancellationToken)
        {
            await _taskService.TaskDone(request.Id, request.Done);

            return new TaskDoneResponse()
            {
                Message = request.Done != false ? "Task marked as done" : "Task marked as not done"
            };
        }
    }
}
