using Models.Concrete.Exceptions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.Exceptions.User
{
    public sealed class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string username) : base($"Username : {username} could not found.") { }

    }
}
