using Models.Abstract.Entities;
using Models.Concrete.Entities.Junctions;

namespace Models.Concrete.Entities
{
    public class Location : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<MovieLocation> Movies { get; set; }
    }
}