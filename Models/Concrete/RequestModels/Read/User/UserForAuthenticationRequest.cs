using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.RequestModels.Read.User
{
    public record UserForAuthenticationRequest
    {
        public string Username { get; init; }
        public string Password { get; init; }
    }
}
