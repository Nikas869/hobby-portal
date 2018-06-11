using HobbyPortal.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HobbyPortal.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/notification")]
    public class NotificationController : Controller
    {
        private readonly NotificationService notificationService;

        public NotificationController(NotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        [Route("{message}")]
        [HttpGet]
        public async Task Post(string message)
        {
            await notificationService.SendNotificationToUser(User.Identity.Name, message);
        }

        [Route("register")]
        [HttpPost]
        public async Task Register()
        {
            await notificationService.TryCreateUserNotificationSettings(User.Identity.Name);
        }
    }
}