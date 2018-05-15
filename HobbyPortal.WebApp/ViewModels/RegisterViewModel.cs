using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace HobbyPortal.WebApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [JsonProperty("password")]
        public string Password { get; set; }

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
    }
}
