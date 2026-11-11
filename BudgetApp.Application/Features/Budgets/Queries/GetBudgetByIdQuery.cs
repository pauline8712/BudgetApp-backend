using BudgetApp.Application.Features.Budgets.DTOs;
using MediatR;

namespace BudgetApp.Application.Features.Budgets.Queries;

// Query för att hämta en specifik budget baserat på Id
public class GetBudgetByIdQuery : IRequest<BudgetDto?>
{
    public Guid Id { get; set; }
}
