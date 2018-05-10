using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HobbyPortal.Infrastructure.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        public string Instructor { get; set; }

        public int ClubId { get; set; }

        public Club Club { get; set; }

        public ICollection<GroupUser> Users { get; set; }
    }
}
