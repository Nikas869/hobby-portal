using HobbyPortal.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyPortal.Infrastructure.Services
{
    public class ClubService
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public ClubService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<Club>> GetParticipatedClubs(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            return context.GroupUsers.Where(groupUser => groupUser.UserId == user.Id).Select(groupUser => groupUser.Group.Club);
        }

        public async Task<IEnumerable<Club>> GetAllClubs()
        {
            return await context.Clubs
                .Include(c => c.City)
                .Include(c => c.Groups)
                .ToArrayAsync();
        }

        public async Task<Club> CreateClub(string userName, Club club)
        {
            var user = await userManager.FindByNameAsync(userName);

            club.Owner = user;
            var createdClub = await context.AddAsync(club);
            await context.SaveChangesAsync();

            return createdClub.Entity;
        }

        public Task<Club> GetClub(int id)
        {
            return context.Clubs.FindAsync(id);
        }
    }
}
