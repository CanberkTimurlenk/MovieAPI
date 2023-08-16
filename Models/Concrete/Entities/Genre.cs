using Models.Abstract.Entities;

namespace Models.Concrete.Entities
{
    public class Genre : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }

        public ICollection<MovieRole>? MovieRoles { get; set; }


    }
}
