using Newtonsoft.Json;
using System.Collections.Generic;

namespace HobbyPortal.WebApp.ViewModels
{
    public class ClubViewModels
    {
        public class ClubViewModel
        {
            public ClubViewModel(string name, string description, string city, string address, IEnumerable<string> groups)
            {
                Name = name;
                Description = description;
                City = city;
                Address = address;
                Groups = groups;
            }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("address")]
            public string Address { get; set; }

            [JsonProperty("groups")]
            public IEnumerable<string> Groups { get; set; }
        }
    }
}
