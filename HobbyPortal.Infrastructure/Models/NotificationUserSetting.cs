using System.ComponentModel.DataAnnotations;

namespace HobbyPortal.Infrastructure.Models
{
    public class NotificationUserSetting
    {
        [Key]
        public int NotificationUserSettingId { get; set; }

        public string NotificationProvider { get; set; }

        public string Setting { get; set; }

        public int UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
