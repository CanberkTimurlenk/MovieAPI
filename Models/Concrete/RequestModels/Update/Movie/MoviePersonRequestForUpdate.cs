
namespace Models.Concrete.RequestModels.Update.Movie
{
    public record MoviePersonRequestForUpdate
    {
        public IEnumerable<int> Person { get; init; }

    }
}
