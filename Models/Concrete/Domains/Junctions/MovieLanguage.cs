using Models.Abstract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.Entities.Junctions
{
    public class MovieLanguage 
    {
        public int MovieId { get; set; }
        public int LanguageId { get; set; }

        public Movie Movie { get; set; }
        public Language Language { get; set; }
    }
}
