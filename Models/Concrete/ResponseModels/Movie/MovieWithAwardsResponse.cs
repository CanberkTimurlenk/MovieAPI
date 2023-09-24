using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Read.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.ResponseModels.Movie
{
    public record MovieWithAwardsResponse
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public DateTime ReleaseDate { get; init; }
        public int DurationAsMinute { get; init; }
        public bool IsReleased { get; init; }
        public HashSet<AwardRequestForMovie> Awards { get; init; }
    }
}
