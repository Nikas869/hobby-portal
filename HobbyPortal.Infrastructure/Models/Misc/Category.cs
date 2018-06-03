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
            Groups = new List<Group>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Group> Groups { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
