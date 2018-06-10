using AutoMapper;
using HobbyPortal.Infrastructure.Models;
using HobbyPortal.WebApp.ViewModels;

namespace HobbyPortal.WebApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Club, ClubSummaryViewModel>()
                .ForMember(dest => dest.ReviewsCount, opt => opt.MapFrom(src => src.Reviews.Count));
            CreateMap<Club, ClubViewModel>();

            CreateMap<Group, GroupSummaryViewModel>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
            CreateMap<Group, GroupViewModel>();

            CreateMap<Review, ReviewViewModel>();

            CreateMap<ApplicationUser, MyAccountViewModel>();
        }
    }
}
