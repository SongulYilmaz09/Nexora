using MediatR;
using Nexora.Application.DTOs.Auth;

namespace Nexora.Application.Features.Auth.Login;

public class LoginCommand : IRequest<LoginResponse>
{
    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}