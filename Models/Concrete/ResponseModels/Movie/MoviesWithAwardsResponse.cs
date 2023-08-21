using Models.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.ResponseModels.Movie
{
    public record MoviesWithAwardsResponse
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public DateTime ReleaseDate { get; init; }
        public int DurationAsMinute { get; init; }
        public bool IsReleased { get; init; }
        public ICollection<Award> Awards { get; init; }
    }
}
