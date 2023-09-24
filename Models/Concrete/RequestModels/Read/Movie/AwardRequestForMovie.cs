namespace Models.Concrete.RequestModels.Read.Movie
{
    public record AwardRequestForMovie
    {
        public DateTime Date { get; init; }
        public string? Description { get; init; }
        public int AwardTypeId { get; init; }

    }
}