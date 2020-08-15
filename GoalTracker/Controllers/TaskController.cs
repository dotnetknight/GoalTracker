using GoalTracker.Web.Commands;
using GoalTracker.Web.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GoalTracker.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(AddTaskCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> DailyTasks()
        {
            return Ok(await _mediator.Send(new DailyTasksPerUserQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> TaskDone(TaskDoneCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}