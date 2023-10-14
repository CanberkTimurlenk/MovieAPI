using Models.Abstract.Entities;

namespace Models.Concrete.Entities
{

    public class MovieDetail : IEntity 
    {
        public int MovieId { get; set; }
        public string Description { get; set; }
        public string Synopsis { get; set; }
        public decimal Budget { get; set; }
        public decimal Revenue { get; set; }
        public Movie Movie { get; set; }

    }
}