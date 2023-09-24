namespace Services.Concrete
{
    public record AwardTypeRequestForInsertion
    {
        public string Name { get; init; }
        public string Description { get; init; }
    }
}