using MediatR;

namespace BudgetApp.Application.Features.Budgets.Commands;

// Command för att ta bort en budget baserat på Id
public class DeleteBudgetCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
