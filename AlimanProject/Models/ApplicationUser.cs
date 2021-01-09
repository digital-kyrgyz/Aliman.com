using Microsoft.AspNetCore.Identity;

namespace AlimanProject.Models
{
    public class ApplicationUser:IdentityUser
    {

        public bool Verified { get; set; }

    }
}