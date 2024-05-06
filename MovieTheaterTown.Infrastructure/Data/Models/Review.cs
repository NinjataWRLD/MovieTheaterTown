using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTheaterTown.Infrastructure.Data.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Message { get; set; } = null!;
        public double Rating { get; set; }

        [Required]
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; } = null!;
    }
}
