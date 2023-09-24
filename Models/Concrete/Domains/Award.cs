using Models.Abstract.Entities;

namespace Models.Concrete.Entities
{
    public class Award : IEntity
    {
        public int AwardTypeId { get; set; }
        public int MovieId { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public Movie Movie { get; set; }
        public AwardType AwardType { get; set; }
    }
}
