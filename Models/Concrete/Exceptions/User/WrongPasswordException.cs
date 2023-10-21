using Models.Concrete.Exceptions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.Exceptions.User
{
    public sealed class InvalidCredentialsException : UnauthorizedException
    {
        public InvalidCredentialsException() : base($"Wrong password or invalid credentials.") { }

        public InvalidCredentialsException(string message) : base(message) { }

    }
}
