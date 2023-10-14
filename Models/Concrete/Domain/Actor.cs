using Models.Abstract.Entities;

namespace Models.Concrete.Entities
{
    public class Actor : MovieRole, IEntity
    {
        public string AlternativeName { get; set; }
        public Person Person { get; set; }

    }

}