using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HobbyPortal.Infrastructure.Models
{
    public class Club
    {
        [Key]
        public int ClubId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public string Town { get; set; }

        public string Address { get; set; }

        public ApplicationUser Owner { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}
