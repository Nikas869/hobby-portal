using System.Threading.Tasks;
using AutoMapper;
using HobbyPortal.Infrastructure.Services;
using HobbyPortal.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HobbyPortal.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/account")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly AccountService accountService;

        public AccountController(AccountService accountService)
        {
            this.accountService = accountService;
        }

        [Route("me")]
        [HttpGet]
        public async Task<MyAccountViewModel> GetMyAccountInfo()
        {
            return Mapper.Map<MyAccountViewModel>(await accountService.GetUserByName(User.Identity.Name));
        }
    }
}