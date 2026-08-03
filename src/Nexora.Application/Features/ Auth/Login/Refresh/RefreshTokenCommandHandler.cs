using MediatR;
using Nexora.Application.DTOs.Auth;
using Nexora.Application.Interfaces;

namespace Nexora.Application.Features.Auth.Refresh;

public class RefreshTokenCommandHandler
    : IRequestHandler<RefreshTokenCommand, RefreshTokenResponse>
{
    private readonly IAuthService _authService;

    public RefreshTokenCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<RefreshTokenResponse> Handle(
        RefreshTokenCommand request,
        CancellationToken cancellationToken)
    {
        var refreshRequest = new RefreshTokenRequest
        {
            RefreshToken = request.RefreshToken
        };

        return await _authService.RefreshTokenAsync(refreshRequest);
    }
}