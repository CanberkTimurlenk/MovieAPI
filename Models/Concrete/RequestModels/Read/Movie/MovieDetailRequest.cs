using Models.Abstract.Entities;

namespace Models.Concrete.RequestModels.Read.Movie

{
    public record MovieDetailRequest
    {
        public string Description { get; set; }
        public string Synopsis { get; set; }
        public decimal Budget { get; set; }
        public decimal Revenue { get; set; }

    }
}