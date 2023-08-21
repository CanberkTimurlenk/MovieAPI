using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.ResponseModels.Movie
{
    public record MovieResponse
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public DateTime ReleaseDate { get; init; }
        public int DurationAsMinute { get; init; }
        public bool IsReleased { get; init; }
    }
}
