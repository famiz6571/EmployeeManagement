using MediatR;

namespace Application.Features.Employees.Commands
{
    public record UpdateEmployeeCommand(Guid Id, string Name, string Department, decimal Salary) : IRequest<Unit>;
}
