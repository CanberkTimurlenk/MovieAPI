using AutoMapper;
using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Insertion.Award;
using Models.Concrete.RequestModels.Insertion.Genre;
using Models.Concrete.RequestModels.Insertion.Language;
using Models.Concrete.RequestModels.Insertion.Location;
using Models.Concrete.RequestModels.Insertion.Movie;
using Models.Concrete.RequestModels.Insertion.Person;
using Models.Concrete.RequestModels.Update.Award;
using Models.Concrete.RequestModels.Update.AwardType;
using Models.Concrete.RequestModels.Update.Genre;
using Models.Concrete.RequestModels.Update.Langauge;
using Models.Concrete.ResponseModels.Movie;
using Services.Concrete;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<AwardTypeRequestForInsertion, AwardType>()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForMember(src => src.Awards, opt => opt.Ignore());

            CreateMap<AwardTypeRequestForUpdate, AwardType>()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForMember(src => src.Awards, opt => opt.Ignore());

            CreateMap<AwardRequestForInsertion, Award>()
                .ForMember(src => src.Movie, opt => opt.Ignore())
                .ForMember(src => src.AwardType, opt => opt.Ignore());

            CreateMap<AwardRequestForUpdate, Award>()
                .ForMember(src => src.Movie, opt => opt.Ignore())
                .ForMember(src => src.AwardType, opt => opt.Ignore());

            CreateMap<LanguageRequestForInsertion, Language>()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForMember(src => src.Movies, opt => opt.Ignore());

            CreateMap<LanguageRequestForUpdate, Language>()
                .ForMember(src => src.Id, opt => opt.Ignore());

            CreateMap<LocationRequestForInsertion, Location>()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForMember(src => src.Movies, opt => opt.Ignore());

            CreateMap<GenreRequestForInsertion, Genre>()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForMember(src => src.Movies, opt => opt.Ignore());

            CreateMap<GenreRequestForUpdate, Genre>()
               .ForMember(src => src.Id, opt => opt.Ignore());

            CreateMap<PersonRequestForInsertion, Person>()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForMember(src => src.Movies, opt => opt.Ignore())
                .ForMember(src => src.Genres, opt => opt.Ignore());
            CreateMap<ActorRequestForInsertion, Actor>()
                .ForMember(src => src.PersonId, opt => opt.Ignore());
            CreateMap<DirectorRequestForInsertion, Actor>()
                .ForMember(src => src.PersonId, opt => opt.Ignore());


            CreateMap<MovieDetailRequestForInsertion, MovieDetail>()
                .ForMember(src => src.Movie, opt => opt.Ignore());



            CreateMap<Movie, MovieResponse>();
            CreateMap<Movie, MovieWithAwardsResponse>();
            CreateMap<Movie, MovieWithDetailsResponse>();

            CreateMap<MovieRequestForInsertion, Movie>().ForMember(src => src.Id, opt => opt.Ignore())
                .ForMember(src => src.Crew, opt => opt.Ignore())
                .ForMember(src => src.Languages, opt => opt.Ignore())
                .ForMember(src => src.Locations, opt => opt.Ignore())
                .ForPath(src => src.MovieDetail.MovieId, opt => opt.Ignore())
                .ForMember(dest => dest.MovieDetail, opt => opt.MapFrom(src =>
                    new MovieDetail
                    {
                        Description = src.MovieDetail.Description,
                        Synopsis = src.MovieDetail.Synopsis,
                        Budget = src.MovieDetail.Budget,
                        Revenue = src.MovieDetail.Revenue
                    }
                ))
                .ForMember(dest => dest.Awards, opt => opt.MapFrom(src =>
                src.Awards.Select(award => new Award
                {
                    Date = award.Date,
                    Description = award.Description,
                    AwardTypeId = award.AwardTypeId
                })));



        }
    }
}
