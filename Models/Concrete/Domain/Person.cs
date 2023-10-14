using Models.Abstract.Domains;
using Models.Abstract.Entities;
using Models.Concrete.Domains.Junctions;
using Models.Concrete.Entities.Junctions;

namespace Models.Concrete.Entities
{

    public class Person : IEntity, IEntityWithHasOwnPk
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Description { get; set; }

        public Actor? Actor { get; set; }
        public Director? Director { get; set; }
        public ICollection<PersonGenre>? Genres { get; set; }
        public ICollection<MoviePerson>? Movies { get; set; }


    }
}
