using AutoMapper;
using MovieTheaterTown.Core.Models;
using MovieTheaterTown.Core.Profiles.DTOs;

namespace MovieTheaterTown.Core.Profiles
{
    public class MovieDTOProfile : Profile
    {
        public MovieDTOProfile()
        {
            ImportToModel();
            ModelToExport();
        }

        private void ImportToModel() => CreateMap<MovieImportDTO, MovieModel>();

        private void ModelToExport() => CreateMap<MovieModel, MovieExportDTO>()
            .ForMember(export  => export.Cast, opt => opt.MapFrom(model => model.Cast.Select(c => c.Name)))
            .ForMember(export  => export.Crew, opt => opt.MapFrom(model => model.Crew.Select(c => c.Name)))
            .ForMember(export  => export.Reviews, opt => opt.MapFrom(model => model.Reviews.Select(r => r.Message)))
            ;
    }
}
