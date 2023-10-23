using Services.Abstract;

namespace Services.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        private readonly ILocationService _locationService;
        private readonly ILanguageService _languageService;
        private readonly IMovieDetailService _movieDetailService;
        private readonly IPersonService _personService;
        private readonly IAwardService _awardService;
        private readonly IAwardTypeService _awardTypeService;
        private readonly IActorService _actorService;
        private readonly IDirectorService _directorService;
        private readonly IAuthenticationService _authenticationService;

        public ServiceManager(IMovieService movieService, IGenreService genreService, ILocationService locationService,
            ILanguageService languageService, IMovieDetailService movieDetailService, IPersonService personService,
            IAwardService awardService, IAwardTypeService awardTypeService, IActorService actorService,
            IDirectorService directorService, IAuthenticationService authenticationService)
        {
            _movieService = movieService;
            _genreService = genreService;
            _locationService = locationService;
            _languageService = languageService;
            _movieDetailService = movieDetailService;
            _personService = personService;
            _awardService = awardService;
            _awardTypeService = awardTypeService;
            _actorService = actorService;
            _directorService = directorService;
            _authenticationService = authenticationService;
        }

        public IMovieService MovieService => _movieService;
        public IGenreService GenreService => _genreService;
        public IAwardService AwardService => _awardService;
        public IAwardTypeService AwardTypeService => _awardTypeService;
        public ILocationService LocationService => _locationService;
        public ILanguageService LanguageService => _languageService;
        public IMovieDetailService MovieDetailService => _movieDetailService;
        public IPersonService PersonService => _personService;
        public IActorService ActorService => _actorService;
        public IDirectorService DirectorService => _directorService;
        public IAuthenticationService AuthenticationService => _authenticationService;


    }
}
