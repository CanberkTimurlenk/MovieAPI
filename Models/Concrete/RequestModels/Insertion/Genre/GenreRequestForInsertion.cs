using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.RequestModels.Insertion.Genre
{
    public record GenreRequestForInsertion
    {
        public string Name { get; init; }
    }
}
