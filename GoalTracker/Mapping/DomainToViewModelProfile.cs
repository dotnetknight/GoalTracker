using AutoMapper;
using GoalTracker.Domain.User;
using GoalTracker.Models.ViewModels;

namespace GoalTracker.Web.Mapping
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<User, MyProfileViewModel>();
        }
    }
}
