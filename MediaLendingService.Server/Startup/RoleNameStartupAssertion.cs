using MediaLendingService.Server.Dto;

namespace MediaLendingService.Server.Startup;

public class RoleNameStartupAssertion : IStartupAssertion
{
    public void Validate()
    {
        if (nameof(UserRoleDto.Customer) != "Customer")
#pragma warning disable CS0162 // Unreachable code detected
        {
            throw new InvalidOperationException($"Name of role {nameof(UserRoleDto.Customer)} must be 'Customer'");
        }
#pragma warning restore CS0162 // Unreachable code detected

        if (nameof(UserRoleDto.Librarian) != "Librarian")
#pragma warning disable CS0162 // Unreachable code detected
        {
            throw new InvalidOperationException($"Name of role {nameof(UserRoleDto.Librarian)} must be 'Librarian'");
        }
#pragma warning restore CS0162 // Unreachable code detected
    }
}