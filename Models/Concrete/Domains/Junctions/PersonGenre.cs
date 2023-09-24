using Models.Concrete.Entities;

namespace Models.Concrete.Domains.Junctions
{
    public class PersonGenre
    {
        public int PersonId { get; set; }
        public int GenreId { get; set; }

        public Person Person { get; set; }
        public Genre Genre { get; set; }
    }
}
