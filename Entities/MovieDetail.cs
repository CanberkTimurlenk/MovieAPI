namespace Entities
{
    public class MovieDetail
    {
        public int MovieId { get; set; }
        public string Description { get; set; }
        public string Synopsis { get; set; }
        public decimal Budget { get; set; }
        public decimal Revenue { get; set; }
        public Movie Movie { get; set; }
        
    }
}