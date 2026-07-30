using Nexora.Domain.Entities;

namespace Nexora.Application.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}