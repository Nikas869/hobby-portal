using HobbyPortal.Infrastructure.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HobbyPortal.Infrastructure
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context, IHostingEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager)
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
                var file = Path.Combine(hostingEnvironment.ContentRootPath, "Data", "categories.txt");
                context.Categories.AddRange(File.ReadAllLines(file).Select(line => new Category(line)));
            }

            if (!context.Users.Any())
            {
                var user = new ApplicationUser("asd@asd.asd", "Микита", "Магда", new DateTime(1997, 5, 3), "0665613628");
                userManager.CreateAsync(user, "asd").Wait();
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
