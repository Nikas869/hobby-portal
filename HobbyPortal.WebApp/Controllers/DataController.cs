using System.Collections.Generic;
using System.Threading.Tasks;
using HobbyPortal.Infrastructure.Models;
using HobbyPortal.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HobbyPortal.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/data")]
    [Authorize]
    public class DataController : Controller
    {
        private readonly MiscDataService miscDataService;

        public DataController(MiscDataService miscDataService)
        {
            this.miscDataService = miscDataService;
        }

        [Route("cities")]
        [HttpGet]
        public async Task<IEnumerable<City>> GetCities(string filter)
        {
            return await miscDataService.GetCities(filter);
        }
    }
}