using MediatR;

namespace Application.Features.Auth.Queries
{
    public record LoginQuery(string Email, string Password) : IRequest<string>;
}
