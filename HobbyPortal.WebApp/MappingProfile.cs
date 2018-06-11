using AutoMapper;
using HobbyPortal.Infrastructure.Models;
using HobbyPortal.WebApp.ViewModels;
using System;
using System.Linq;

namespace HobbyPortal.WebApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Club, ClubSummaryViewModel>()
                .ForMember(dest => dest.ReviewsCount, opt => opt.MapFrom(src => src.Reviews.Count))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Reviews.Any() ? Math.Round(src.Reviews.Average(rev => rev.Rating), 1) : 0));
            CreateMap<Club, ClubViewModel>();

            CreateMap<Group, GroupSummaryViewModel>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
            CreateMap<Group, GroupViewModel>();

            CreateMap<Review, ReviewViewModel>();

            CreateMap<ApplicationUser, MyAccountViewModel>();
        }
    }
}
