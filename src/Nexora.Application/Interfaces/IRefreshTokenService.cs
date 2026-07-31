using Nexora.Domain.Entities;

namespace Nexora.Application.Interfaces;

public interface IRefreshTokenService
{
    RefreshToken Generate(User user);
}