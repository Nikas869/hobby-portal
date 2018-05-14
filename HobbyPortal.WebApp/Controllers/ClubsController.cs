using HobbyPortal.Infrastructure.Models;
using HobbyPortal.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

        [Route("myclubs")]
        [HttpGet]
        public async Task<IEnumerable<Club>> GetParticipatedClubs()
        {
            return await clubService.GetParticipatedClubs(User.Identity.Name);
        }

        [HttpPost]
        public async Task<ActionResult> CreateClub(Club club)
        {
            var createdClub = await clubService.CreateClub(User.Identity.Name, club);

            return Ok(createdClub.ClubId);
        }

        //// GET: api/Clubs/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetClub([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var club = await context.Clubs.SingleOrDefaultAsync(m => m.ClubId == id);

        //    if (club == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(club);
        //}

        //// PUT: api/Clubs/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutClub([FromRoute] int id, [FromBody] Club club)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != club.ClubId)
        //    {
        //        return BadRequest();
        //    }

        //    context.Entry(club).State = EntityState.Modified;

        //    try
        //    {
        //        await context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ClubExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Clubs
        //[HttpPost]
        //public async Task<IActionResult> PostClub([FromBody] Club club)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    club.Owner = await userManager.GetUserAsync(User);
        //    context.Clubs.Add(club);
        //    await context.SaveChangesAsync();

        //    return CreatedAtAction("GetClub", new { id = club.ClubId }, club);
        //}

        //// DELETE: api/Clubs/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteClub([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var club = await context.Clubs.SingleOrDefaultAsync(m => m.ClubId == id);
        //    if (club == null)
        //    {
        //        return NotFound();
        //    }

        //    context.Clubs.Remove(club);
        //    await context.SaveChangesAsync();

        //    return Ok(club);
        //}

        //private bool ClubExists(int id)
        //{
        //    return context.Clubs.Any(e => e.ClubId == id);
        //}
    }
}