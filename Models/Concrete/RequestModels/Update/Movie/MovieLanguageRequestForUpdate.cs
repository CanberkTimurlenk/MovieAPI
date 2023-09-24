
namespace Models.Concrete.RequestModels.Update.Movie
{
    public record MovieLanguageRequestForUpdate
    {
        public IEnumerable<int> Language { get; init; }

    }
}
