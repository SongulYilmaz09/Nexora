using Nexora.Application.DTOs.Users;
using Nexora.Application.Interfaces;

namespace Nexora.Infrastructure.Services;

public class UserService : IUserService
{
    public Task CreateAsync(CreateUserRequest request)
    {
        return Task.CompletedTask;
    }
}