namespace Domain.Interfaces;

using Domain.Entities;

public interface IEmployeeRepository
{
    Task AddAsync(Employee employee);
    Task<List<Employee>> GetAllAsync();
    Task<Employee?> GetByIdAsync(Guid id);
    Task UpdateAsync(Employee employee);
    Task DeleteAsync(Employee employee);
}
