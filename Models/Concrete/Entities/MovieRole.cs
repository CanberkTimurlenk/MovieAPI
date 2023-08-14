using Models.Abstract.Entities;

namespace Models.Concrete.Entities
{
    public class MovieRole : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Person> Persons { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Genre> Genres { get; set; }

    }
}
