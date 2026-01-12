using MediatR;

public record CreateEmployeeCommand(string Name, string Department, decimal Salary) : IRequest<Guid>;
