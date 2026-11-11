using BudgetApp.Application.Features.Budgets.DTOs;
using MediatR;

namespace BudgetApp.Application.Features.Budgets.Queries;

// Query för att hämta alla budgetar för en specifik användare
public class GetAllBudgetsQuery : IRequest<List<BudgetDto>>
{
    // Filtrerar budgetar per användare
    public Guid UserId { get; set; }
}
