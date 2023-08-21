using AutoMapper;
using Models.Concrete.Entities;
using Models.Concrete.ResponseModels.Movie;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieResponse>();
            CreateMap<Movie, MoviesWithAwardsResponse>();
        }
    }
}
