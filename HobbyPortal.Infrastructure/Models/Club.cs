using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HobbyPortal.Infrastructure.Models
{
    public class Club
    {
        [Key]
        public int ClubId { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("description")]
        public string Description { get; set; }

        [Required]
        [JsonProperty("townId")]
        public string TownId { get; set; }

        public Town Town { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [Required]
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string OwnerId { get; set; }

        public ApplicationUser Owner { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}
