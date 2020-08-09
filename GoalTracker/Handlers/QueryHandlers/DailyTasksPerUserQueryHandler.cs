using GoalTracker.Models.Responses;
using GoalTracker.Services.Task_service;
using GoalTracker.Web.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace GoalTracker.Web.Handlers.QueryHandlers
{
    public class DailyTasksPerUserQueryHandler : IRequestHandler<DailyTasksPerUserQuery, DailyTasksResponse>
    {
        private readonly ITaskService _taskService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DailyTasksPerUserQueryHandler(ITaskService taskService, IHttpContextAccessor httpContextAccessor)
        {
            _taskService = taskService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<DailyTasksResponse> Handle(DailyTasksPerUserQuery request, CancellationToken cancellationToken)
        {
            return new DailyTasksResponse
            {
                DailyTasks = await _taskService.DailyTasks(
                    _httpContextAccessor.HttpContext.User.FindFirst(
                        ClaimTypes.Email).Value)
            };
        }
    }
}