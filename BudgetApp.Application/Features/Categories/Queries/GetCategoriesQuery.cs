using BudgetApp.Application.Features.Categories.DTOs;
using MediatR;

namespace BudgetApp.Application.Features.Categories.Queries;

public class GetCategoriesQuery : IRequest<List<CategoryDto>>
{
    public Guid BudgetId { get; set; }
}
