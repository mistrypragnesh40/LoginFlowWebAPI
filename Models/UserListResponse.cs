namespace WebAPIDemo.Models
{
    public class UserListResponse
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public char Gender { get; set; }
    }
}
