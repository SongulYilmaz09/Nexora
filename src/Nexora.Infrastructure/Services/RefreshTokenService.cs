using System.Security.Cryptography;
using Nexora.Application.Interfaces;
using Nexora.Domain.Entities;

namespace Nexora.Infrastructure.Services;

public class RefreshTokenService : IRefreshTokenService
{
    public RefreshToken Generate(User user)
    {
        var randomBytes = RandomNumberGenerator.GetBytes(64);

        var token = Convert.ToBase64String(randomBytes);

        return new RefreshToken
        {
            Id = Guid.NewGuid(),
            Token = token,
            UserId = user.Id,
            User = user,
            ExpiresAt = DateTime.UtcNow.AddDays(7),
            IsRevoked = false
        };
    }
}