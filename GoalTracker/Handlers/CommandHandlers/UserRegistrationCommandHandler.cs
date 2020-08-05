using GoalTracker.Domain.User;
using GoalTracker.Models.Responses;
using GoalTracker.Services.User_Service;
using GoalTracker.Web.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GoalTracker.Web.Handlers.CommandHandlers
{
    public class RegisterUserCommandHandler : IRequestHandler<UserRegistrationCommand, Response>
    {
        private IUserService _userService;

        public RegisterUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Response> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
        {
            _userService.TestMethod();

            User userEntity = new User
            {
                AddedDate = DateTime.UtcNow,
                Email = request.Email,
                LastName = request.LastName,
                FirstName = request.FirstName,
                Password = _userService.PasswordHash(request.Password)
            };

            await _userService.RegisterUser(userEntity);

            return new Response
            {
                Message = "You have successfully created an account"
            };
        }
    }
}
