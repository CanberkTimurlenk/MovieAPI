using Microsoft.AspNetCore.Identity;
using Models.Concrete.Exceptions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.Exceptions.User
{
    public sealed class UserRegistrationException : BadRequestException
    {
        public IEnumerable<IdentityError> Errors { get; private set; }
        public UserRegistrationException() : base("Registration was not successful") { }
        public UserRegistrationException(string message) : base(message) { }

        public UserRegistrationException(IEnumerable<IdentityError> errors)
        {
            var builder = new StringBuilder();

            foreach (var item in errors)
                builder.Append(item.Description);

            throw new UserRegistrationException(builder.ToString().TrimEnd());
        }

    }
}
