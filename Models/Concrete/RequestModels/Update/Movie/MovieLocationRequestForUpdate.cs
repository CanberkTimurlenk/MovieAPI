

namespace Models.Concrete.RequestModels.Update.Movie
{
    public record MovieLocationRequestForUpdate
    {
        public IEnumerable<int> Location { get; init; }

    }
}
