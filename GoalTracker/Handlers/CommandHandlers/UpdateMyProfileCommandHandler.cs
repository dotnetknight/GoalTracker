using GoalTracker.Models.Exceptions;
using GoalTracker.Models.Responses;
using GoalTracker.Services.User_Service;
using GoalTracker.Web.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace GoalTracker.Web.Handlers.CommandHandlers
{
    public class UpdateMyProfileCommandHandler : IRequestHandler<UpdateMyProfileCommand, UpdateMyProfileResponse>
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateMyProfileCommandHandler(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UpdateMyProfileResponse> Handle(UpdateMyProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.UserCredentialsByEmail(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value);

            if (user == null)
                throw new BaseApiException(System.Net.HttpStatusCode.NotFound, "User not found.");

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;

            if (!string.IsNullOrEmpty(request.Password))
                user.Password = _userService.PasswordHash(request.Password);

            await _userService.UpdateMyProfile();

            return new UpdateMyProfileResponse
            {
                Message = "Your profile has successfully updated. Please re enter your credentials to process your changes."
            };
        }
    }
}
