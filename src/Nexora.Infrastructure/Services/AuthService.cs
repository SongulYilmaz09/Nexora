using Microsoft.EntityFrameworkCore;
using Nexora.Application.DTOs.Auth;
using Nexora.Application.Interfaces;
using Nexora.Persistence.Context;

namespace Nexora.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly NexoraDbContext _context;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtService _jwtService;
    private readonly IRefreshTokenService _refreshTokenService;

    public AuthService(
        NexoraDbContext context,
        IPasswordHasher passwordHasher,
        IJwtService jwtService,
        IRefreshTokenService refreshTokenService)
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
        _refreshTokenService = refreshTokenService;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Email == request.Email);

        if (user is null)
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        var isPasswordValid = _passwordHasher.VerifyPassword(
            request.Password,
            user.PasswordHash);

        if (!isPasswordValid)
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

       var accessToken = _jwtService.GenerateToken(user);

var refreshToken = _refreshTokenService.Generate(user);

// Refresh Token'ı veritabanına kaydet
_context.RefreshTokens.Add(refreshToken);

await _context.SaveChangesAsync();

return new LoginResponse
{
    AccessToken = accessToken,
    RefreshToken = refreshToken.Token
};
    }
    public async Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request)
{
    var refreshToken = await _context.RefreshTokens
        .Include(x => x.User)
        .FirstOrDefaultAsync(x => x.Token == request.RefreshToken);

    if (refreshToken is null)
    {
        throw new UnauthorizedAccessException("Invalid refresh token.");
    }

    if (refreshToken.IsRevoked)
    {
        throw new UnauthorizedAccessException("Refresh token has been revoked.");
    }

    if (refreshToken.ExpiresAt <= DateTime.UtcNow)
    {
        throw new UnauthorizedAccessException("Refresh token has expired.");
    }

refreshToken.IsRevoked = true;
refreshToken.RevokedAt = DateTime.UtcNow;

var newRefreshToken = _refreshTokenService.Generate(refreshToken.User);

_context.RefreshTokens.Add(newRefreshToken);

await _context.SaveChangesAsync();

var accessToken = _jwtService.GenerateToken(refreshToken.User);

return new RefreshTokenResponse
{
    AccessToken = accessToken,
    RefreshToken = newRefreshToken.Token
};
}
}