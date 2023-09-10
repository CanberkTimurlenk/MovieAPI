using Models.Abstract.Entities;

namespace Models.Concrete.Entities.Junctions
{
    public class MoviePerson : IEntity
    {
        public int MovieId { get; set; }
        public int PersonId { get; set; }

        public Movie Movie { get; set; }
        public Person Person { get; set; }
    }
}
