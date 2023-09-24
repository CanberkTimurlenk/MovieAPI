using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Models.Concrete.Entities;
using Repositories.Abstract.Base;

namespace Repositories.Abstract
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        void RemoveRangePersonGenres(int personId, IEnumerable<int> genreIds);
        void RemovePersonGenre(int personId, int genreId);
        Task AddRangePersonGenresAsync(int personId, IEnumerable<int> genreIds);
        Task<IEnumerable<int>> GetGenreIds(int personId);
 
    }
}