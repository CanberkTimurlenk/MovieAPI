using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.Exceptions
{
    public sealed class MovieNotFoundException : NotFoundException
    {
        public MovieNotFoundException(int id) : base($"The Movie with id : {id} could not found.")
        {

        }
    }
}
