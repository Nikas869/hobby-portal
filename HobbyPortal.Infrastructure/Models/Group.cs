using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HobbyPortal.Infrastructure.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("instructor")]
        public string Instructor { get; set; }

        [Required]
        [JsonProperty("place")]
        public string Place { get; set; }

        [Required]
        [JsonProperty("contacts")]
        public string InstructorContacts { get; set; }

        [Required]
        [JsonProperty("minAge")]
        public int? MinAge { get; set; }

        [Required]
        [JsonProperty("maxAge")]
        public int? MaxAge { get; set; }

        [Required]
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int ClubId { get; set; }

        public Club Club { get; set; }

        public ICollection<GroupUser> Users { get; set; }
    }
}
