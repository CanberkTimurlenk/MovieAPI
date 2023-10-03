using Models.Abstract.RequestFeatures;

namespace Models.Concrete.RequestFeatures
{
    public class MovieParameters : RequestParameters
    {
        public string? OrderBy { get; set; }
    }
}
