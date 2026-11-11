using System;

namespace BudgetApp.Application.Features.Budgets.DTOs;

// DTO för att returnera budgetdata till klienten
public class BudgetDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; }
}
