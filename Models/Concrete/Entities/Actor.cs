using Models.Abstract.Entities;

namespace Models.Concrete.Entities
{
    public class Actor : MovieRole, IEntity
    {

        public override string ToString()
        
            => nameof(Actor);
    }

}