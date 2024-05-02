namespace MovieTheaterTown.Core.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Plot { get; set; } = null!;
        public string[] Cast { get; set; } = [];
        public string[] Crew { get; set; } = [];
        public string[] Reviews { get; set; } = [];
    }
}
