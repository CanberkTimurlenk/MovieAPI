using Models.Abstract.Entities;

namespace Models.Concrete.Entities
{
    public class Award : IEntity
    {
        public int Year { get; set; }
        public string? Description { get; set; }
        public int AwardTypeId { get; set; }
        public Movie Movie { get; set; }
        public AwardType AwardType { get; set; }


    }
}
