using BudgetApp.Application.Features.Budgets.DTOs;
using MediatR;

namespace BudgetApp.Application.Features.Budgets.Commands;

// Command för att uppdatera en befintlig budget
public class UpdateBudgetCommand : IRequest<BudgetDto>
{
    // Id sätts från URL-parametern i controllern
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal TotalAmount { get; set; }
}
