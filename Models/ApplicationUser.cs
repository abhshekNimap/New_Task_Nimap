using Microsoft.AspNetCore.Identity;

namespace MovieDetailsAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
