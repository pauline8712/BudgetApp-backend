using System;

namespace BudgetApp.Application.Features.Budgets.DTOs;

// DTO för budgetsammanfattning — returneras av GetBudgetSummaryQuery
//DTO:n för summary. Det är den som definierar hur svaret ska se ut när frontend tar emot datan.
public class BudgetSummaryDto
{
    // Grundläggande budgetinformation
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal TotalAmount { get; set; }

    // Lista med alla kategorier och deras saldo
    public List<CategorySummaryDto> Categories { get; set; } = new List<CategorySummaryDto>();

    // Totalt spenderat belopp — summan av alla kategoriers (AllocatedAmount - CurrentBalance)
    public decimal TotalSpent { get; set; }

    // Återstående belopp — TotalAmount minus TotalSpent
    public decimal RemainingAmount { get; set; }
}

