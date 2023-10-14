using Models.Abstract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.Entities.Junctions
{
    public class MovieLocation
    {
        public int MovieId { get; set; }
        public int LocationId { get; set; }

        public Movie Movie { get; set; }
        public Location Location { get; set; }
    }
}
