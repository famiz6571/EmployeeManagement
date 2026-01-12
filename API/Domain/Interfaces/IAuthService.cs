namespace Domain.Interfaces;
public interface IAuthService
{
    Task<Guid> RegisterAsync(string email, string password, string role);
    Task<string> LoginAsync(string email, string password);
}
