using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HobbyPortal.Infrastructure.Models
{
    public class Club
    {
        public Club()
        {
            this.Groups = new List<Group>();
            this.Reviews = new List<Review>();
        }

        [Key]
        public int ClubId { get; set; }

        [Required]
        [MaxLength(120)]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(450)]
        [JsonProperty("description")]
        public string Description { get; set; }

        [Required]
        [MaxLength(20)]
        [JsonProperty("phone")]
        [NotMapped]
        public string Phone { get; set; }

        [Required]
        [JsonProperty("cityId")]
        public int CityId { get; set; }

        public City City { get; set; }

        [Required]
        [MaxLength(120)]
        [JsonProperty("address")]
        public string Address { get; set; }

        public string OwnerId { get; set; }

        public ApplicationUser Owner { get; set; }

        public List<Group> Groups { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
