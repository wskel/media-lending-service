namespace MediaLendingService.Server.Dto;

public enum UserRoleDto
{
    Customer,
    Librarian
}

public static class UserRoleDtoExtensions
{
    private const string RequireRolePrefix = "RequireRole";

    // ReSharper disable once EntityNameCapturedOnly.Global
    public static string GetRoleName(this UserRoleDto role) =>
        role.ToString();

    public static string GetRequireRolePolicyName(this UserRoleDto role) =>
        $"{RequireRolePrefix}{role.GetRoleName()}";
}