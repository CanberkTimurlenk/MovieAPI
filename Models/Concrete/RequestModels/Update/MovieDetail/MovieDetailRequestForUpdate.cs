using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.RequestModels.Update.MovieDetailRequestForUpdate
{
    public record MovieDetailRequestForUpdate
    {
        public string Description { get; init; }
        public string Synopsis { get; init; }
        public decimal Budget { get; init; }
        public decimal Revenue { get; init; }
    }
}
