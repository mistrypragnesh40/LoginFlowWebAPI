namespace WebAPIDemo.Models
{
    public class RegisterUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public char Gender { get; set; }
    }
}
