using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.Tokens
{
    public record Token
    {
        public string AccessToken { get; init; }
        public string RefreshToken { get; init; }

    }
}
