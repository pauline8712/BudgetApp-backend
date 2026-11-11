using BudgetApp.Application.Features.Users.DTOs;
using MediatR;

namespace BudgetApp.Application.Features.Users.Commands;

// Command för att skapa en ny användare — skickas via MediatR
public class CreateUserCommand : IRequest<UserDto>
{
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = "User";
}
