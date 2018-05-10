using System.ComponentModel.DataAnnotations;

namespace HobbyPortal.Infrastructure.Models
{
    public class GroupUser
    {
        [Key]
        public int GroupUserId { get; set; }

        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}
