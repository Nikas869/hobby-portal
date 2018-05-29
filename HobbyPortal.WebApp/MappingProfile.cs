using AutoMapper;
using HobbyPortal.Infrastructure.Models;
using System.Linq;
using static HobbyPortal.WebApp.ViewModels.ClubViewModels;

namespace HobbyPortal.WebApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Club, ClubViewModel>()
                .ForMember(vm => vm.City, opt => opt.MapFrom(club => club.City.Name))
                .ForMember(vm => vm.Category, opt => opt.MapFrom(club => club.Category.Name))
                .ForMember(vm => vm.Groups, opt => opt.MapFrom(club => club.Groups.Select(group => group.Name)));
        }
    }
}
