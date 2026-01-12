using MediatR;
using Domain.Entities;

public record GetEmployeeByIdQuery(Guid Id) : IRequest<Employee?>;
