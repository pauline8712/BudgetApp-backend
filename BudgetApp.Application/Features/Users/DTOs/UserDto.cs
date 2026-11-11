using System;

namespace BudgetApp.Application.Features.Users.DTOs;

// DTO för att returnera användardata till klienten — innehåller aldrig PasswordHash
public class UserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
