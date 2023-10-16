using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.RequestModels.Insertion.User
{
    public record UserForRegisterRequest
    {
        public string? Firstname { get; init; }
        public string? Lastname { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public string Email { get; init; }
        public string? PhoneNumber { get; init; }

    }
}
