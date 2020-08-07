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
    public class RegisterUserCommandHandler : IRequestHandler<UserRegistrationCommand, UserRegistrationResponse>
    {
        private IUserService _userService;

        public RegisterUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserRegistrationResponse> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
        {
            User userEntity = new User
            {
                AddedDate = DateTime.UtcNow,
                Email = request.Email,
                LastName = request.LastName,
                FirstName = request.FirstName,
                Password = _userService.PasswordHash(request.Password)
            };

            await _userService.SignUp(userEntity);

            return new UserRegistrationResponse
            {
                Message = "You have successfully created an account"
            };
        }
    }
}
