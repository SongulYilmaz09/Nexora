using Nexora.Application.DTOs.Users;
using Nexora.Application.Interfaces;
using Nexora.Domain.Entities;

namespace Nexora.Infrastructure.Services;

public class UserService : IUserService
{
    public Task CreateAsync(CreateUserRequest request)
    {
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,

            // Şimdilik hash yapmıyoruz.
            // JWT/Auth sprintinde BCrypt ile hashleyeceğiz.
            PasswordHash = request.Password
        };

        Console.WriteLine($"User Created: {user.FirstName} {user.LastName}");

        return Task.CompletedTask;
    }
}