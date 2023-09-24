using Models.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.ResponseModels.Movie
{
    public record MovieWithDetailsResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int DurationAsMinute { get; set; }
        public bool IsReleased { get; set; }

        public MovieDetail MovieDetail { get; set; }

    }
}
