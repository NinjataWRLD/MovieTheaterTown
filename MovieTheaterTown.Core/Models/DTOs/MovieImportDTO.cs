namespace MovieTheaterTown.Core.Profiles.DTOs
{
    public class MovieImportDTO
    {
        public string Name { get; set; } = null!;
        public string Plot { get; set; } = null!;
        public string[] Cast { get; set; } = [];
        public string[] Crew { get; set; } = [];
        public string[] Reviews { get; set; } = [];
    }
}
