namespace Entities
{
    public class Award
    {               
        public int Year { get; set; }
        public string? Description { get; set; }
        public int AwardTypeId { get; set; }
        public Movie Movie { get; set; }
        public AwardType AwardType { get; set; }


    }
}
