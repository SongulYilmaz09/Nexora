using Nexora.Application.DTOs.Users;

namespace Nexora.Application.Interfaces;

public interface IUserService
{
    Task CreateAsync(CreateUserRequest request);
}