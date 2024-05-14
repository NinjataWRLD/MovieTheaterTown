using System.ComponentModel.DataAnnotations;

namespace MovieTheaterTown.Infrastructure.Data.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Plot { get; set; } = null!;

        public ICollection<Cast> Cast { get; set; } = [];
        public ICollection<Crew> Crew { get; set; } = [];
        public ICollection<Review> Reviews { get; set; } = [];
        public ICollection<UserMovie> Saved { get; set; } = [];
    }
}
