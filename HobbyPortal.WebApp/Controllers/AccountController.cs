using System.Threading.Tasks;
using AutoMapper;
using HobbyPortal.Infrastructure.Models;
using HobbyPortal.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HobbyPortal.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/account")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [Route("me")]
        [HttpGet]
        public async Task<MyAccountViewModel> GetMyAccountInfo()
        {
            return Mapper.Map<MyAccountViewModel>(await userManager.FindByNameAsync(User.Identity.Name));
        }
    }
}