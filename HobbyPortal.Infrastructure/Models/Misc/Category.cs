using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HobbyPortal.Infrastructure.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Club> Clubs { get; set; }
    }
}
