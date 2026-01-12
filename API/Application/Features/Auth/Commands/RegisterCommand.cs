using MediatR;

namespace Application.Features.Auth.Commands
{
    public record RegisterCommand(string Email, string Password, string Role) : IRequest<Guid>;
}
