using MediatR;
using Domain.Entities;

public record GetEmployeesQuery() : IRequest<List<Employee>>;
