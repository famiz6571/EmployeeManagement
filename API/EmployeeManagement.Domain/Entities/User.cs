using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
