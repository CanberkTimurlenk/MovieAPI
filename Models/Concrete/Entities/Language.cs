using Models.Abstract.Entities;

namespace Models.Concrete.Entities
{
    public class Language : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
