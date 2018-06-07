using AutoMapper;
using HobbyPortal.Infrastructure.Models;
using HobbyPortal.WebApp.ViewModels;
using System.Linq;
using static HobbyPortal.WebApp.ViewModels.ClubViewModels;

namespace HobbyPortal.WebApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Club, ClubViewModel>()
                .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.Groups.Select(group => group.Name)));
            CreateMap<ApplicationUser, MyAccountViewModel>();
        }
    }
}
