using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HobbyPortal.Infrastructure.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [Required]
        [JsonProperty("birthday")]
        public DateTime Birthday { get; set; }

        [Required]
        [JsonProperty("phone")]
        public string Phone { get; set; }

        public ICollection<Club> Clubs { get; set; }

        public ICollection<GroupUser> Groups { get; set; }
    }
}
