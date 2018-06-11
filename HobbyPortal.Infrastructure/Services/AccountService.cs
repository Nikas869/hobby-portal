using HobbyPortal.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyPortal.Infrastructure.Services
{
    public class AccountService
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<ApplicationUser> GetUserByName(string name)
        {
            return await context.Users.Where(user => user.UserName.ToLowerInvariant() == name.ToLowerInvariant())
                .Include(u => u.Groups)
                .FirstOrDefaultAsync();
        }
    }
}
