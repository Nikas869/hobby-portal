using HobbyPortal.Infrastructure.Exceptions.NotificationExceptions;
using HobbyPortal.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace HobbyPortal.Infrastructure.Services
{
    public class NotificationService
    {
        private readonly ITelegramBotClient telegramBotClient;
        private readonly IConfiguration configuration;
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public NotificationService(
            IConfiguration configuration,
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            ITelegramBotClient telegramBotClient)
        {
            this.configuration = configuration;
            this.context = context;
            this.userManager = userManager;
            this.telegramBotClient = telegramBotClient;
        }

        public async Task TryCreateUserNotificationSettings(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);

            await CheckExistingSettings(user.Id, NotificationProvider.Telegram.ToString());

            var updates = await telegramBotClient.GetUpdatesAsync(allowedUpdates: new[] { UpdateType.Message });
            var registerRequest = updates.Where(update => update.Message.Text == user.Id)
                .OrderBy(update => update.Message.Date).FirstOrDefault();

            if (registerRequest == null)
            {
                throw new MessageNotFoundException();
            }

            context.NotificationUserSettings.Add(new NotificationUserSetting(
                NotificationProvider.Telegram.ToString(),
                registerRequest.Message.Chat.Id.ToString(),
                user.Id));
            await context.SaveChangesAsync();

            await SendWelcomeMessage(user, registerRequest.Message.Chat.Id);
        }

        public async Task SendNotificationToUser(string userName, string notificationText)
        {
            var user = await userManager.FindByNameAsync(userName);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            var userContact = context.NotificationUserSettings.Where(settings => settings.User == user).First().Setting;
            var chat = new ChatId(userContact);
        }

        private async Task CheckExistingSettings(string id, string providerName)
        {
            var existingSettingsCount = await context.NotificationUserSettings
                .CountAsync(notification => notification.UserId == id && notification.NotificationProvider == providerName);

            if (existingSettingsCount > 0)
            {
                throw new SettingAlreadyExistException($"You already have settings for {providerName}!");
            }
        }

        private async Task SendWelcomeMessage(ApplicationUser user, long chatId)
        {
            await telegramBotClient.SendTextMessageAsync(
                new ChatId(chatId),
                $"Ласкаво просимо, {user.FirstName} {user.LastName}! " +
                $"Тепер ви будете отримувати сповіщення від адміністрації клубів, у яких ви є учасником.");
        }
    }
}
