using Models.Abstract.Entities;
using Models.Concrete.Entities.Junctions;

namespace Models.Concrete.Entities
{
    public class Language : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<MovieLanguage> Movies { get; set; }
    }
}
