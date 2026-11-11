using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Application.Features.Categories.DTOs;

// DTO för att returnera kategoridata till klienten
public class CategoryDto
{
    public Guid Id { get; set; }
    public Guid BudgetId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal AllocatedAmount { get; set; }
    public decimal CurrentBalance { get; set; }
    public DateTime CreatedAt { get; set; }


    // Om kategorin är veckobaserad
    public bool IsWeekly { get; set; }

    // Veckobelopp — null om IsWeekly är false
    public decimal? WeeklyAmount { get; set; }
}
