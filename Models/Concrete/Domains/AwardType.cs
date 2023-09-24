using Models.Abstract.Domains;
using Models.Abstract.Entities;

namespace Models.Concrete.Entities
{
    public class AwardType : IEntity, IEntityWithHasOwnPk
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Award> Awards { get; set; }
    }
}
