using BudgetApp.Application.Features.Users.DTOs;
using MediatR;

namespace BudgetApp.Application.Features.Users.Commands;

// Command för att uppdatera en befintlig användare
public class UpdateUserCommand : IRequest<UserDto>
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}
