using Microsoft.EntityFrameworkCore;
using Nexora.Application.DTOs.Users;
using Nexora.Application.Interfaces;
using Nexora.Domain.Entities;
using Nexora.Persistence.Context;

namespace Nexora.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly NexoraDbContext _context;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(
        NexoraDbContext context,
        IPasswordHasher passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task CreateAsync(CreateUserRequest request)
    {
        var emailExists = await _context.Users.AnyAsync(u => u.Email == request.Email);

        if (emailExists)
        {
            throw new InvalidOperationException("A user with this email already exists.");
        }

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PasswordHash = _passwordHasher.HashPassword(request.Password)
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}