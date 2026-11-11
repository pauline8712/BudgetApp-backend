using MediatR;

namespace BudgetApp.Application.Features.Users.Commands;

// Command för att ta bort en användare baserat på Id
public class DeleteUserCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
