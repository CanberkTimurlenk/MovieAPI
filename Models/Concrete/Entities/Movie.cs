using Models.Abstract.Entities;
using Models.Concrete.Entities.Junctions;

namespace Models.Concrete.Entities
{
    public class Movie : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int DurationAsMinute { get; set; }
        public bool IsReleased { get; set; }


        public MovieDetail MovieDetail { get; set; }
        public ICollection<MoviePerson>? Crew { get; set; }
        public ICollection<MovieGenre> Genres { get; set; }
        public ICollection<MovieLanguage> Languages { get; set; }
        public ICollection<MovieLocation> Locations { get; set; }
        public ICollection<Award> Awards { get; set; }

    }
}