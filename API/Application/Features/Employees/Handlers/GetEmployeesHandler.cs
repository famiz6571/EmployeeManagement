using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Employees.Handlers
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesQuery, List<Employee>>
    {
        private readonly IEmployeeRepository _repo;

        public GetEmployeesHandler(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAllAsync();
        }
    }
}
