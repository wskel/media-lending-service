using MediaLendingService.Server.Dto;
using Microsoft.AspNetCore.Identity;

namespace MediaLendingService.Server.Identity;

public sealed class ApplicationRole : IdentityRole<Guid>
{
    public ApplicationRole() { }

    public ApplicationRole(UserRoleDto userRole)
    {
        Name = userRole.GetRoleName();
    }
}