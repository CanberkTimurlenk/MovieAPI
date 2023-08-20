using Repositories.Concrete.EFCore;

namespace Repositories.Abstract;

public interface IRepositoryManager
{
    IMovieRepository Movie { get; }
    Task SaveAsync();
}