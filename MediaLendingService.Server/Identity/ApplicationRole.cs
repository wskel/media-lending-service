using MediaLendingService.Server.Dto;
using Microsoft.AspNetCore.Identity;
using NuGet.Protocol;

namespace MediaLendingService.Server.Identity;

public sealed class ApplicationRole : IdentityRole<Guid>
{
    private ApplicationRole() { }

    public ApplicationRole(UserRoleDto userRole)
    {
        Id = Guid.NewGuid();
        Name = userRole.GetRoleName();
        NormalizedName = userRole.GetRoleName().ToUpperInvariant();
        ConcurrencyStamp = Guid.NewGuid().ToString();
    }

    public ApplicationRole(Guid id, string name, string normalizedName, string concurrencyStamp)
    {
        Id = id;
        Name = name;
        NormalizedName = normalizedName;
        ConcurrencyStamp = concurrencyStamp;
    }
}