using GoalTracker.Models.Exceptions;
using GoalTracker.Models.Responses;
using GoalTracker.Services.User_Service;
using GoalTracker.Web.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GoalTracker.Web.Handlers.CommandHandlers
{

    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, UserLoginResponse>
    {
        private IUserService _userService;

        public UserLoginCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserLoginResponse> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                throw new BaseApiException(System.Net.HttpStatusCode.BadRequest, "Invalid credentials provided");

            var token = await _userService.AuthenticationToken(request.Email, request.Password);

            return new UserLoginResponse
            {
                Message = "You have successfully logged in",
                Token = token
            };
        }
    }
}