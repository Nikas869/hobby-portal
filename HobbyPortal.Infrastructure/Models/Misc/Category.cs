using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HobbyPortal.Infrastructure.Models
{
    public class Category
    {
        public Category(string name) : base()
        {
            Name = name;
        }

        protected Category()
        {
            Clubs = new List<Club>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Club> Clubs { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
