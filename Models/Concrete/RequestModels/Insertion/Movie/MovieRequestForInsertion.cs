using Models.Concrete.RequestModels.Read.Movie;

namespace Models.Concrete.RequestModels.Insertion.Movie
{
    public record MovieRequestForInsertion
    {

        public string Title { get; init; }
        public DateTime ReleaseDate { get; init; }
        public int DurationAsMinute { get; init; }
        public bool IsReleased { get; init; }

        public MovieDetailRequest MovieDetail { get; init; }
        public List<int>? CrewMemberId { get; init; }
        public List<int> GenreId { get; init; }
        public List<int> LanguageId { get; init; }
        public List<int> LocationId { get; init; }
        public List<AwardRequestForMovie> Awards { get; init; }

    }
}
