using Models.Abstract.Entities;
using Models.Concrete.Entities.Junctions;

namespace Models.Concrete.Entities
{
    public class Genre : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<MovieGenre> Movies { get; set; }
        public ICollection<Person>? Persons { get; set; }
    }
}
