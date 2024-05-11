using Microsoft.AspNetCore.Identity;

namespace MovieTheaterTown.Infrastructure.Data.Models
{
    public class AppRole : IdentityRole<Guid>
    {
        public AppRole() : base() { }
        public AppRole(string roleName) : base(roleName) { }
    }
}
