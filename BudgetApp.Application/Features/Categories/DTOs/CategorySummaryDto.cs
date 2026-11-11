using System;

namespace BudgetApp.Application.Features.Budgets.DTOs;

// DTO för kategorisammanfattning — ingår i BudgetSummaryDto
public class CategorySummaryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal AllocatedAmount { get; set; }
    public decimal CurrentBalance { get; set; }
    // Hur mycket som är spenderat i kategorin
    public decimal AmountSpent { get; set; }
    // Om kategorin är veckobaserad
    public bool IsWeekly { get; set; }
    // Veckobelopp — null om IsWeekly är false
    public decimal? WeeklyAmount { get; set; }
}
