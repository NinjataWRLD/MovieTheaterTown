using MovieTheaterTown.Infrastructure.Data.Models;

namespace MovieTheaterTown.Core.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Plot { get; set; } = null!;
        public List<Cast> Cast { get; set; } = [];
        public List<Crew> Crew { get; set; } = [];
        public List<Review> Reviews { get; set; } = [];
    }
}
