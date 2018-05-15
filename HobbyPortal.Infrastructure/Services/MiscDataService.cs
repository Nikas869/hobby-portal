using HobbyPortal.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyPortal.Infrastructure.Services
{
    public class MiscDataService
    {
        private readonly ApplicationDbContext context;

        public MiscDataService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<City>> GetCities(string filter)
        {
            return await context.Cities.Where(city => city.Name.ToLowerInvariant().Contains(filter.ToLowerInvariant())).Take(10).ToArrayAsync();
        }
    }
}
