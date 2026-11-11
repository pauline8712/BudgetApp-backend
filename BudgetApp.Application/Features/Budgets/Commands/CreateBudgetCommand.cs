using BudgetApp.Application.Features.Budgets.DTOs;
using MediatR;

namespace BudgetApp.Application.Features.Budgets.Commands;

// Command för att skapa en ny budget — skickas via MediatR
public class CreateBudgetCommand : IRequest<BudgetDto>
{
    // Kopplar budgeten till en specifik användare
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    // Månad och år definierar vilken period budgeten gäller
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal TotalAmount { get; set; }
}
