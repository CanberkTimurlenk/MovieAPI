
namespace Models.Concrete.RequestModels.Update.Movie
{
    public record MovieGenreRequestForUpdate
    {
        public IEnumerable<int> Genre { get; init; }
    }
}
