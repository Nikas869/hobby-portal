using Newtonsoft.Json;

namespace HobbyPortal.WebApp.ViewModels
{
    public class MyAccountViewModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }
    }
}
