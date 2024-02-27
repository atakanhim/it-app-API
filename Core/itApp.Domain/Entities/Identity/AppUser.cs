using Microsoft.AspNetCore.Identity;

namespace itApp.Domain.Entities.Identity
{
    public class AppUser: IdentityUser<string>
    {
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenEndDate { get; set; }

        // Navigation property for employees added by this user
        public ICollection<Employe> Employees { get; set; }
    }
}
