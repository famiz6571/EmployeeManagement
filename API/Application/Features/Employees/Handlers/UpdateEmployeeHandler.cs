using Application.Features.Employees.Commands;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Employees.Handlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        private readonly IEmployeeRepository _repo;

        public UpdateEmployeeHandler(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repo.GetByIdAsync(request.Id);
            if (employee == null)
                throw new KeyNotFoundException("Employee not found");

            employee.Name = request.Name;
            employee.Department = request.Department;
            employee.Salary = request.Salary;

            await _repo.UpdateAsync(employee);
            return Unit.Value;
        }
    }
}
