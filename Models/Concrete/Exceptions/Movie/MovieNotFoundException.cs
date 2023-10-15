using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Concrete.Exceptions.Common;

namespace Models.Concrete.Exceptions.Movie
{
    public sealed class MovieNotFoundException : NotFoundException
    {
        public MovieNotFoundException(int id) : base($"The Movie with id : {id} could not found.")
        {

        }
    }
}
