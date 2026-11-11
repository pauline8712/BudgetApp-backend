using MediatR;

namespace BudgetApp.Application.Features.Categories.Commands;

public class DeleteCategoryCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
