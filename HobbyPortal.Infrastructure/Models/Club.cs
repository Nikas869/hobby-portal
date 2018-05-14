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
        [JsonProperty("title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("town")]
        public string Town { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        public string OwnerId { get; set; }

        public ApplicationUser Owner { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}
