using Models.Abstract.Entities;

namespace Models.Concrete.Entities
{
    public class MovieRole : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Person> Persons { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public ICollection<Genre> Genres { get; set; }

    }
}
