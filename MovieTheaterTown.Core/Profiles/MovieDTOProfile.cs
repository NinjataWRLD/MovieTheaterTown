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

        private void ModelToExport() => CreateMap<MovieModel, MovieExportDTO>();
    }
}
