using MediatR;
using Nexora.Application.DTOs.Auth;

namespace Nexora.Application.Features.Auth.Refresh;

public class RefreshTokenCommand : IRequest<RefreshTokenResponse>
{
    public string RefreshToken { get; set; } = string.Empty;
}