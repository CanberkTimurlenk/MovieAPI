namespace Services.Abstract
{
    public interface IServiceManager
    {
        public IMovieService MovieService { get; }
        public ILocationService LocationService { get; }
        public IPersonService PersonService { get; }
        public ILanguageService LanguageService { get; }
        public IMovieDetailService MovieDetailService { get; }
        public IGenreService GenreService { get; }
        public IAwardTypeService AwardTypeService { get; }
        public IAwardService AwardService { get; }
        public IActorService ActorService { get; }
        public IDirectorService DirectorService { get; }
        public IAuthenticationService AuthenticationService { get; }


    }
}
