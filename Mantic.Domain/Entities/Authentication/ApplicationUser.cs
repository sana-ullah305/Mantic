
using Microsoft.AspNetCore.Identity;

namespace Mantic.Domain.Entities.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
