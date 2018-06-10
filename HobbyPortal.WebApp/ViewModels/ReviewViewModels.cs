using Newtonsoft.Json;

namespace HobbyPortal.WebApp.ViewModels
{
    public class ReviewViewModel
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }
    }
}
