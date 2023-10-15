
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace Models.Concrete.Domain
{
    public class User : IdentityUser
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
