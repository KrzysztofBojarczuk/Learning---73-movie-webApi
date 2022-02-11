using AutoMapper;
using MovieWebApplication1.Dttos;
using MovieWebApplication1.Models;

namespace MovieWebApplication1.Automapper
{
    public class MovieMappingProfiles : Profile
    {
        public MovieMappingProfiles()
        {
            CreateMap<MovieCreateDto, Movie>();
            CreateMap<Movie, MovieGetDto>();
        }
    }
}
