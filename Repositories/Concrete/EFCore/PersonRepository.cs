using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models.Concrete.Domains.Junctions;
using Models.Concrete.Entities;
using Models.Concrete.Entities.Junctions;
using Repositories.Abstract;
using Repositories.Abstract.Base.EFCore;
using Repositories.Concrete.EFCore.Contexts;

namespace Repositories.Concrete.EFCore
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(MovieContext context) : base(context)
        {

        }

        public void RemoveRangePersonGenres(int personId, IEnumerable<int> genreIds)
        {

            var moviePersonList = new List<PersonGenre>();

            foreach (var id in genreIds)
                moviePersonList.Add(new PersonGenre { PersonId = personId, GenreId = id, });

            _context.Set<PersonGenre>().RemoveRange(moviePersonList);

        }
        public void RemovePersonGenre(int personId, int genreId)
        {
            _context.Set<PersonGenre>().Remove(new PersonGenre { PersonId = personId, GenreId = genreId });
        }
        public async Task AddRangePersonGenres(int personId, IEnumerable<int> genreIds)
        {

            var personGenreList = new List<PersonGenre>();

            foreach (var id in genreIds)
                personGenreList.Add(new PersonGenre { PersonId = personId, GenreId = id, });

            await _context.Set<PersonGenre>().AddRangeAsync(personGenreList);

        }
        public async Task<IEnumerable<int>> GetGenreIds(int personId)
        {
            return await _context.Set<PersonGenre>().Where(m => m.PersonId == personId)
                                                    .AsNoTracking()
                                                    .Select(m => m.GenreId)
                                                    .ToListAsync();
        }
        public async Task AddRangePersonGenresAsync(int personId, IEnumerable<int> genreIds)
        {

            var movieGenreList = new List<PersonGenre>();

            foreach (var id in genreIds)
                movieGenreList.Add(new PersonGenre { PersonId = personId, GenreId = id, });

            await _context.Set<PersonGenre>().AddRangeAsync(movieGenreList);

        }
        
       
    }
}
