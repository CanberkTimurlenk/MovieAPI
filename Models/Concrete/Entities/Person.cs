using Models.Abstract.Entities;
using Models.Concrete.Entities.Junctions;

namespace Models.Concrete.Entities
{

    public class Person : IEntity
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Description { get; set; }

        public ICollection<MovieRole> MovieRoles { get; set; }
        public ICollection<MoviePerson>? Movies { get; set; }
        public ICollection<Genre>? Genres { get; set; }


    }
}
