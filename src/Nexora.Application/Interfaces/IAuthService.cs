using Nexora.Application.DTOs.Auth;

namespace Nexora.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
}