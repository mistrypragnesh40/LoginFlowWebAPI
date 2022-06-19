namespace WebAPIDemo.Models
{
    public class AuthenticateResponse
    {
        public string Token { get; set; }
        public UserDTO UserDetail { get; set; }
    }
}
