using HobbyPortal.Infrastructure.Models;
using HobbyPortal.Infrastructure.Services;
using HobbyPortal.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HobbyPortal.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/auth")]
    [Authorize]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly MiscDataService miscDataService;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            MiscDataService miscDataService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.miscDataService = miscDataService;
        }

        [Route("register")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = new ApplicationUser(model.Email, model.FirstName, model.LastName, model.Birthday, model.Phone);
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var userClaims = await userManager.GetClaimsAsync(user);

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),

                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName)
                }.Union(userClaims);

                var token = new JwtSecurityToken(
                    issuer: configuration["Authentication:Issuer"],
                    audience: configuration["Authentication:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    notBefore: DateTime.Now,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SigningKey"])), SecurityAlgorithms.HmacSha256));

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return BadRequest(result.Errors);
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                return Unauthorized();
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            var userClaims = await userManager.GetClaimsAsync(user);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),

                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName)
            }.Union(userClaims);

            var token = new JwtSecurityToken(
                issuer: configuration["Authentication:Issuer"],
                audience: configuration["Authentication:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                notBefore: DateTime.Now,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SigningKey"])), SecurityAlgorithms.HmacSha256));

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        [Route("cities")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<City>> GetCities(string filter)
        {
            return await miscDataService.GetCities(filter);
        }

        [Route("info")]
        [HttpGet]
        public string GetUserInfo()
        {
            return User.Identity.Name;
        }
    }
}
