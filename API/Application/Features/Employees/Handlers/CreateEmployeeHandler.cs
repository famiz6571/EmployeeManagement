using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Employees.Handlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IEmployeeRepository _repo;

        public CreateEmployeeHandler(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Department = request.Department,
                Salary = request.Salary
            };

            await _repo.AddAsync(employee);
            return employee.Id;
        }
    }
}
