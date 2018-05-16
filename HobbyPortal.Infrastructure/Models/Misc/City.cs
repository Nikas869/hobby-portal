using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HobbyPortal.Infrastructure.Models
{
    public class City
    {
        public City(string name) : this()
        {
            Name = name;
        }

        protected City()
        {
            Clubs = new List<Club>();
        }

        [Key]
        public int CityId { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Club> Clubs { get; set; }
    }
}
