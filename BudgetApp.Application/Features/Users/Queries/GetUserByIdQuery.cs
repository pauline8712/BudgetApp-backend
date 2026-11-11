using BudgetApp.Application.Features.Users.DTOs;
using MediatR;

namespace BudgetApp.Application.Features.Users.Queries;

// Query för att hämta en specifik användare baserat på Id
public class GetUserByIdQuery : IRequest<UserDto>
{
    public Guid Id { get; set; }
}
