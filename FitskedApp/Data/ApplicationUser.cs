using FitskedApp.Models;
using Microsoft.AspNetCore.Identity;

namespace FitskedApp.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Plan>? Plans { get; set; }
    }

}
