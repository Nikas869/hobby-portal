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
        [JsonProperty("cityId")]
        public int CityId { get; set; }

        [Required]
        [JsonProperty("city")]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Club> Clubs { get; set; }
    }
}
