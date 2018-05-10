using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace HobbyPortal.Infrastructure.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Club> Clubs { get; set; }

        public ICollection<GroupUser> Groups { get; set; }
    }
}
