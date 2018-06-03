using System.ComponentModel.DataAnnotations;

namespace HobbyPortal.Infrastructure.Models
{
    public class NotificationUserSetting
    {
        public NotificationUserSetting(string notificationProvider, string setting, string userId)
        {
            NotificationProvider = notificationProvider;
            Setting = setting;
            UserId = userId;
        }

        [Key]
        public int NotificationUserSettingId { get; set; }

        public string NotificationProvider { get; set; }

        public string Setting { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
