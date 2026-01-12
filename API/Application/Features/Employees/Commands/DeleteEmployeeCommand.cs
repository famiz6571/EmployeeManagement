using MediatR;

namespace Application.Features.Employees.Commands
{
    public record DeleteEmployeeCommand(Guid Id) : IRequest<Unit>;
}
