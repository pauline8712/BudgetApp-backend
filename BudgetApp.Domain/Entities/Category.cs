using System;
using System.Collections.Generic;

namespace BudgetApp.Domain.Entities;

public class Category
{
    public Guid Id { get; set; }
    public Guid BudgetId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal AllocatedAmount { get; set; }
    public decimal CurrentBalance { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Om kategorin är veckobaserad — t.ex. Mat med 500 kr/vecka
    public bool IsWeekly { get; set; } = false;

    // Veckobelopp — används endast om IsWeekly är true
    public decimal? WeeklyAmount { get; set; }

    public Budget? Budget { get; set; }
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
