using Models.Abstract.Entities;

namespace Models.Concrete.Entities
{
    public class Movie : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int DurationAsMinute { get; set; }
        public bool IsInTheaters { get; set; }


        public List<MovieRole>? MovieRoles { get; set; }
        public List<Genre> Genres { get; set; }
        public MovieDetail MovieDetail { get; set; }
        public List<Language> Languages { get; set; }
        public List<Location> Locations { get; set; }
        public List<Award> Awards { get; set; }
    }
}