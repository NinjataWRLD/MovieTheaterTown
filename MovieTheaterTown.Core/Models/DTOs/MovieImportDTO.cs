using MovieTheaterTown.Infrastructure.Data.Models;

namespace MovieTheaterTown.Core.Profiles.DTOs
{
    public class MovieImportDTO
    {
        public string Name { get; set; } = null!;
        public string Plot { get; set; } = null!;
        public Cast[] Cast { get; set; } = [];
        public Crew[] Crew { get; set; } = [];
        public Review[] Reviews { get; set; } = [];
    }
}
