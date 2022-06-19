using WebAPIDemo.Data;

namespace WebAPIDemo.Models
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Role { get; set; }
        public int? RoleID { get; set; }
    }
}
