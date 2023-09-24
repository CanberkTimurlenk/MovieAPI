using Models.Concrete.Entities;

namespace Services.Concrete
{
    public record MovieDetailRequestForInsertion
    {
        public int MovieId { get; init; }
        public string Description { get; init; }
        public string Synopsis { get; init; }
        public decimal Budget { get; init; }
        public decimal Revenue { get; init; }
    }
}