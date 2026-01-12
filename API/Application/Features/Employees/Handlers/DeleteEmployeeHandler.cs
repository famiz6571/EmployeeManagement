using Application.Features.Employees.Commands;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Employees.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly IEmployeeRepository _repo;

        public DeleteEmployeeHandler(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repo.GetByIdAsync(request.Id);
            if (employee == null)
                throw new KeyNotFoundException("Employee not found");

            await _repo.DeleteAsync(employee);
            return Unit.Value;
        }
    }
}
