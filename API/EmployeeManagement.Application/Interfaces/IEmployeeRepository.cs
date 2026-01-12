using EmployeeManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(int id);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<int> CreateAsync(Employee employee);
        Task<int> UpdateAsync(Employee employee);
        Task<int> DeleteAsync(int id);
    }
}
