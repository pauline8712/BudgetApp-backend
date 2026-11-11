using BudgetApp.Application.Features.Categories.DTOs;
using MediatR;

namespace BudgetApp.Application.Features.Categories.Queries;

public class GetCategoryByIdQuery : IRequest<CategoryDto?>
{
    public Guid Id { get; set; }
}
