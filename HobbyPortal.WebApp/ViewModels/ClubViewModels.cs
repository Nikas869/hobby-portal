using Newtonsoft.Json;
using System.Collections.Generic;

namespace HobbyPortal.WebApp.ViewModels
{
    public class ClubSummaryViewModel
    {
        [JsonProperty("id")]
        public int ClubId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("reviewsCount")]
        public int ReviewsCount { get; set; }

        [JsonProperty("groups")]
        public IEnumerable<GroupSummaryViewModel> Groups { get; set; }
    }

    public class ClubViewModel : ClubSummaryViewModel
    {
        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("groups")]
        public new IEnumerable<GroupViewModel> Groups { get; set; }

        [JsonProperty("reviews")]
        public IEnumerable<ReviewViewModel> Reviews { get; set; }
    }
}
