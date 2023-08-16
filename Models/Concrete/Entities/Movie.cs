using Models.Abstract.Entities;

namespace Models.Concrete.Entities
{
    public class Movie : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int DurationAsMinute { get; set; }
        public bool IsReleased { get; set; }


        public ICollection<MovieRole>? MovieRoles { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public MovieDetail MovieDetail { get; set; }
        public ICollection<Language> Languages { get; set; }
        public ICollection<Location> Locations { get; set; }
        public ICollection<Award> Awards { get; set; }
    }
}