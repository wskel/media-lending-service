using MediaLendingService.Server.Dto;
using Microsoft.AspNetCore.Authorization;

namespace MediaLendingService.Server.Identity;

public static class AuthorizationBuilderExtensions
{
    public static AuthorizationBuilder AddPolicyRequireRole(this AuthorizationBuilder builder, UserRoleDto role)
    {
        var policyName = role.GetRequireRolePolicyName();
        return builder.AddPolicy(policyName, policy => policy.RequireRole(role.GetRoleName()));
    }
}