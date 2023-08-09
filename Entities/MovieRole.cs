namespace Entities
{
    public class MovieRole
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Person> Persons { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Genre> Genres { get; set; }

    }
}
