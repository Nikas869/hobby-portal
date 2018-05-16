using HobbyPortal.Infrastructure.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HobbyPortal.Infrastructure
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            context.Database.EnsureCreated();

            if (!context.Cities.Any())
            {
                var file = Path.Combine(hostingEnvironment.ContentRootPath, "Data", "cities.json");
                var cities = JsonConvert.DeserializeObject<CitiesList>(File.ReadAllText(file));

                context.Cities.AddRange(cities.Cities.Select(city => new City(city.Name)));
            }

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(new[]
                {
                    new Category("Спорт"),
                    new Category("Музика"),
                    new Category("Малювання")
                });
            }

            context.SaveChanges();
        }

        private class CitiesList
        {
            [JsonProperty("cities")]
            public ICollection<CityListItem> Cities { get; set; }
        }

        private class CityListItem
        {
            [JsonProperty("name_ua")]
            public string Name { get; set; }
        }
    }
}
