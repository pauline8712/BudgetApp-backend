using BudgetApp.Application.Features.Budgets.DTOs;
using MediatR;

namespace BudgetApp.Application.Features.Budgets.Queries;

// Query för att hämta en budgetsammanfattning med kategorier och saldo — skickas via MediatR
public class GetBudgetSummaryQuery : IRequest<BudgetSummaryDto?>
{
    // Id på budgeten vars sammanfattning ska hämtas
    public Guid BudgetId { get; set; }
}
