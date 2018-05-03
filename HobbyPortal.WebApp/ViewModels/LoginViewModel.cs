using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HobbyPortal.WebApp.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
