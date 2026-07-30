using Nexora.Application.DTOs.Users;
using Nexora.Application.Interfaces;
using Nexora.Domain.Entities;
using Nexora.Persistence.Context;

namespace Nexora.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly NexoraDbContext _context;

    public UserService(NexoraDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(CreateUserRequest request)
    {
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,

            // Şimdilik hash yapmıyoruz.
            // Authentication sprintinde BCrypt kullanacağız.
            PasswordHash = request.Password
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}