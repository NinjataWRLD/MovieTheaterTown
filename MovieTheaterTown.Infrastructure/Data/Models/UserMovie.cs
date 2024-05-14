using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTheaterTown.Infrastructure.Data.Models
{
    [PrimaryKey(nameof(Username), nameof(MovieId))]
    public class UserMovie
    {
        public string Username { get; set; } = null!;

        public int MovieId { get; set; }
        
        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; } = null!;
    }
}
