namespace Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public List<Movie> Movies { get; set; }

        public List<MovieRole>? MovieRoles { get; set; }
        

    }
}
