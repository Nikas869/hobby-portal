using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HobbyPortal.Infrastructure.Models
{
    public class Town
    {
        [Key]
        public int TownId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Club> Clubs { get; set; }
    }
}
