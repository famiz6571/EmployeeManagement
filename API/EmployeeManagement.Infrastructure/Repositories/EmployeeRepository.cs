using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;
        public EmployeeRepository(EmployeeContext context) => _context = context;

        public async Task<int> CreateAsync(Employee employee)
        {
            var parameters = new[]
            {
                new SqlParameter("@FirstName", employee.FirstName),
                new SqlParameter("@LastName", employee.LastName),
                new SqlParameter("@Email", employee.Email),
                new SqlParameter("@Phone", employee.Phone),
                new SqlParameter("@DateOfBirth", employee.DateOfBirth),
                new SqlParameter("@DateOfJoining", employee.DateOfJoining),
                new SqlParameter("@Department", employee.Department),
                new SqlParameter("@Designation", employee.Designation),
                new SqlParameter("@Salary", employee.Salary),
                new SqlParameter("@Address", employee.Address),
                new SqlParameter("@City", employee.City),
                new SqlParameter("@Country", employee.Country),
                new SqlParameter("@ZipCode", employee.ZipCode),
                new SqlParameter("@EmergencyContact", employee.EmergencyContact),
                new SqlParameter("@BloodGroup", employee.BloodGroup),
                new SqlParameter("@MaritalStatus", employee.MaritalStatus)
            };
            return await _context.ExecuteStoredProcedureAsync("sp_CreateEmployee", parameters);
        }

        public async Task<int> DeleteAsync(int id) =>
            await _context.ExecuteStoredProcedureAsync("sp_DeleteEmployee", new SqlParameter("@Id", id));

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var list = new List<Employee>();
            using var reader = await _context.ExecuteReaderAsync("sp_GetAllEmployees");
            while (await reader.ReadAsync())
            {
                list.Add(new Employee
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Email = reader.GetString(3),
                    Department = reader.GetString(6),
                    Designation = reader.GetString(7),
                    Salary = reader.GetDecimal(8),
                    IsActive = reader.GetBoolean(16)
                });
            }
            return list;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            using var reader = await _context.ExecuteReaderAsync("sp_GetEmployeeById", new SqlParameter("@Id", id));
            if (await reader.ReadAsync())
            {
                return new Employee
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Email = reader.GetString(3),
                    Department = reader.GetString(6),
                    Designation = reader.GetString(7),
                    Salary = reader.GetDecimal(8),
                    IsActive = reader.GetBoolean(16)
                };
            }
            return null;
        }

        public async Task<int> UpdateAsync(Employee employee)
        {
            var parameters = new[]
            {
                new SqlParameter("@Id", employee.Id),
                new SqlParameter("@FirstName", employee.FirstName),
                new SqlParameter("@LastName", employee.LastName),
                new SqlParameter("@Email", employee.Email),
                new SqlParameter("@Phone", employee.Phone),
                new SqlParameter("@DateOfBirth", employee.DateOfBirth),
                new SqlParameter("@DateOfJoining", employee.DateOfJoining),
                new SqlParameter("@Department", employee.Department),
                new SqlParameter("@Designation", employee.Designation),
                new SqlParameter("@Salary", employee.Salary),
                new SqlParameter("@Address", employee.Address),
                new SqlParameter("@City", employee.City),
                new SqlParameter("@Country", employee.Country),
                new SqlParameter("@ZipCode", employee.ZipCode),
                new SqlParameter("@EmergencyContact", employee.EmergencyContact),
                new SqlParameter("@BloodGroup", employee.BloodGroup),
                new SqlParameter("@MaritalStatus", employee.MaritalStatus),
                new SqlParameter("@IsActive", employee.IsActive)
            };
            return await _context.ExecuteStoredProcedureAsync("sp_UpdateEmployee", parameters);
        }
    }
}
