using AutoMapper;
using HobbyPortal.Infrastructure.Models;
using HobbyPortal.Infrastructure.Services;
using HobbyPortal.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HobbyPortal.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/clubs")]
    [Authorize]
    public class ClubsController : Controller
    {
        private readonly IMapper mapper;
        private readonly ClubService clubService;

        public ClubsController(IMapper mapper, ClubService clubService)
        {
            this.mapper = mapper;
            this.clubService = clubService;
        }

        [Route("")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<ClubSummaryViewModel>> GetAllClubs()
        {
            var clubs = await clubService.GetAllClubs();
            return mapper.Map<IEnumerable<Club>, IEnumerable<ClubSummaryViewModel>>(clubs);
        }

        [Route("myclubs")]
        [HttpGet]
        public async Task<IEnumerable<Club>> GetParticipatedClubs()
        {
            return await clubService.GetParticipatedClubs(User.Identity.Name);
        }

        [Route("")]
        [HttpPost]
        public async Task<ActionResult> CreateClub([FromBody] Club club)
        {
            var createdClub = await clubService.CreateClub(User.Identity.Name, club);

            return CreatedAtAction("GetClub", createdClub.ClubId);
        }

        [Route("{id:int}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<ClubViewModel> GetClub(int id)
        {
            return mapper.Map<ClubViewModel>(await clubService.GetClub(id));
        }
    }
}