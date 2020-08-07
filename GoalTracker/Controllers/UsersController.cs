using System.Threading.Tasks;
using GoalTracker.Web.Commands;
using GoalTracker.Web.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoalTracker.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] UserRegistrationCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<bool> UserByEmail(string email)
        {
            return await _mediator.Send(new UserByEmailQuery(email));
        }
    }
}