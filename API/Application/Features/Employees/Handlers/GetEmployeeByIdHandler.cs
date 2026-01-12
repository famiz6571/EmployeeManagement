using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Employees.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee?>
    {
        private readonly IEmployeeRepository _repo;

        public GetEmployeeByIdHandler(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<Employee?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetByIdAsync(request.Id);
        }
    }
}
