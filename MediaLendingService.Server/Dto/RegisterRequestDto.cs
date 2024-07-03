using System.ComponentModel.DataAnnotations;

namespace MediaLendingService.Server.Dto;

// ReSharper disable once ClassNeverInstantiated.Global
public record RegisterRequestDto(
    [Required] [EmailAddress] string Email,
    [Required] [DataType(DataType.Password)]
    string Password,
    [MaxLength(100)] string? PreferredName,
    UserRoleDto Role
);