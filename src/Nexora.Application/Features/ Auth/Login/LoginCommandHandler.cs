using MediatR;
using Nexora.Application.DTOs.Auth;
using Nexora.Application.Interfaces;

namespace Nexora.Application.Features.Auth.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IAuthService _authService;

    public LoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginResponse> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        return await _authService.LoginAsync(new LoginRequest
        {
            Email = request.Email,
            Password = request.Password
        });
    }
}