using Models.Concrete.Exceptions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.Exceptions.User
{
    internal class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string email) : base($"The User with id : {email} could not found.")
        {

        }
    }
}
