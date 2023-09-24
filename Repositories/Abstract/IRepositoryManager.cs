using Repositories.Concrete.EFCore;

namespace Repositories.Abstract;

public interface IRepositoryManager
{
    IMovieRepository Movie { get; }
    IGenreRepository Genre { get; }
    ILocationRepository Location { get; }
    ILanguageRepository Language { get; }
    IAwardRepository Award { get; }
    IAwardTypeRepository AwardType { get; }
    IPersonRepository Person { get; }
    IMovieDetailRepository MovieDetail { get; }
    IActorRepository Actor { get; }
    IDirectorRepository Director { get; }
    

    Task SaveAsync();
}