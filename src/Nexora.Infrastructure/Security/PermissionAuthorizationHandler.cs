using Microsoft.AspNetCore.Authorization;

namespace Nexora.Infrastructure.Security;

public class PermissionAuthorizationHandler
    : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        // Şimdilik sadece kullanıcının giriş yapmış olmasını kontrol ediyoruz.
        if (context.User.Identity?.IsAuthenticated == true)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}