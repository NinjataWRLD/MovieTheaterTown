namespace MovieTheaterTown.API.Models
{
    public class LoginModel
    {
        public string Password { get; set; } = null!;
        public string Username { get; set; } = null!;
        public bool RememberMe { get; set; }
    }
}
