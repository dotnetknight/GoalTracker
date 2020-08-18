using AutoMapper;
using GoalTracker.Models.Exceptions;
using GoalTracker.Models.ViewModels;
using GoalTracker.Services.User_Service;
using GoalTracker.Web.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace GoalTracker.Web.Handlers.QueryHandlers
{
    public class MyProfileQueryHandler : IRequestHandler<MyProfileQuery, MyProfileViewModel>
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public MyProfileQueryHandler(IUserService userService, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        public async Task<MyProfileViewModel> Handle(MyProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.UserCredentialsByEmail(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value);

            if (user == null)
                throw new BaseApiException(System.Net.HttpStatusCode.NotFound, "User not found.");

            return _mapper.Map<MyProfileViewModel>(user);
        }
    }
}
