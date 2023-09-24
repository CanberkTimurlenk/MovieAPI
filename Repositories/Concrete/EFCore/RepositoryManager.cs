using Repositories.Abstract;
using Repositories.Concrete.EFCore.Contexts;


namespace Repositories.Concrete.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly MovieContext _context;
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IAwardRepository _awardRepository;
        private readonly IAwardTypeRepository _awardTypeRepository;
        private readonly IMovieDetailRepository _movieDetailRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IDirectorRepository _directoryRepository;
        

        public RepositoryManager(MovieContext context, IMovieRepository movieRepository, IGenreRepository genreRepository,
            ILocationRepository locationRepository, IAwardRepository awardRepository, IAwardTypeRepository awardTypeRepository,
            IMovieDetailRepository movieDetailRepository, IPersonRepository personRepository, ILanguageRepository languageRepository,
            IActorRepository actorRepository, IDirectorRepository directoryRepository
            )
        {
            _context = context;
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _locationRepository = locationRepository;
            _awardRepository = awardRepository;
            _awardTypeRepository = awardTypeRepository;
            _movieDetailRepository = movieDetailRepository;
            _personRepository = personRepository;
            _languageRepository = languageRepository;
            _actorRepository = actorRepository;
            _directoryRepository = directoryRepository;
            
        }

        public IMovieRepository Movie => _movieRepository;
        public IGenreRepository Genre => _genreRepository;
        public ILocationRepository Location => _locationRepository;
        public IAwardRepository Award => _awardRepository;
        public IAwardTypeRepository AwardType => _awardTypeRepository;
        public IMovieDetailRepository MovieDetail => _movieDetailRepository;
        public IPersonRepository Person => _personRepository;
        public ILanguageRepository Language => _languageRepository;
        public IActorRepository Actor => _actorRepository;
        public IDirectorRepository Director => _directoryRepository;


        public async Task SaveAsync() => await _context.SaveChangesAsync();

    }
}
