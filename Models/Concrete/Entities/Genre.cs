using Models.Abstract.Entities;

namespace Models.Concrete.Entities
{
    public class Genre : IEntity
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public List<Movie> Movies { get; set; }

        public List<MovieRole>? MovieRoles { get; set; }


    }
}
