using BudgetApp.Application.Features.Categories.DTOs;
using MediatR;

namespace BudgetApp.Application.Features.Categories.Commands;

// Command för att uppdatera en befintlig kategori — skickas via MediatR
public class UpdateCategoryCommand : IRequest<CategoryDto>
{

    // Id på kategorin som ska uppdateras — sätts från URL-parametern i controllern
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal AllocatedAmount { get; set; }

    // Om kategorin är veckobaserad — t.ex. Mat med 500 kr/vecka
    public bool IsWeekly { get; set; } = false;

    // Veckobelopp — används endast om IsWeekly är true
    public decimal? WeeklyAmount { get; set; }
}
