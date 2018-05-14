using HobbyPortal.Infrastructure.Models;
using HobbyPortal.Infrastructure.Services;
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
        private readonly ClubService clubService;

        public ClubsController(ClubService clubService)
        {
            this.clubService = clubService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<Club>> GetAllClubs()
        {
            return await clubService.GetAllClubs();
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

        [Route("/{id:int}")]
        [HttpGet]
        public async Task<Club> GetClub(int id)
        {
            return await clubService.GetClub(id);
        }
    }
}