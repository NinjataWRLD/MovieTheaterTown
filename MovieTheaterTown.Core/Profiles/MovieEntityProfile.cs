using AutoMapper;
using MovieTheaterTown.Core.Models;
using MovieTheaterTown.Infrastructure.Data.Models;

namespace MovieTheaterTown.Core.Profiles
{
    public class MovieEntityProfile : Profile
    {
        public MovieEntityProfile() 
        {
            EntityToModel();
            ModelToEntity();
        }

        private void EntityToModel() => CreateMap<Movie, MovieModel>();
        private void ModelToEntity() => CreateMap<MovieModel, Movie>();
    }
}
