using Models.Abstract.Domains;
using Models.Abstract.Entities;
using Models.Concrete.Entities.Junctions;

namespace Models.Concrete.Entities
{
    public class Language : IEntity, IEntityWithHasOwnPk
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MovieLanguage> Movies { get; set; }
    }
}
