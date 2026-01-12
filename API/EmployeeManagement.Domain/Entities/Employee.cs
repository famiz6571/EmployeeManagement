using System;

namespace EmployeeManagement.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string EmergencyContact { get; set; }
        public string BloodGroup { get; set; }
        public string MaritalStatus { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
