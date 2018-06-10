using Newtonsoft.Json;

namespace HobbyPortal.WebApp.ViewModels
{
    public class GroupSummaryViewModel
    {
        [JsonProperty("id")]
        public int GroupId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
    }

    public class GroupViewModel : GroupSummaryViewModel
    {
        [JsonProperty("instructor")]
        public string Instructor { get; set; }

        [JsonProperty("place")]
        public string Place { get; set; }

        [JsonProperty("contacts")]
        public string InstructorContacts { get; set; }

        [JsonProperty("minAge")]
        public int? MinAge { get; set; }

        [JsonProperty("maxAge")]
        public int? MaxAge { get; set; }
    }
}
