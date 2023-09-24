using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.RequestModels.Update.Person
{
    public class PersonGenreRequestForUpdate
    {
        public IEnumerable<int> Genre { get; init; }
    }
}
