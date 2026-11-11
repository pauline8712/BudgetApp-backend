using BudgetApp.Application.Interfaces;
using MediatR;

namespace BudgetApp.Application.Features.Budgets.Commands;

// Hanterar DeleteBudgetCommand — tar bort en budget från databasen
public class DeleteBudgetCommandHandler : IRequestHandler<DeleteBudgetCommand, bool>
{
    private readonly IBudgetRepository _budgetRepository;

    // IBudgetRepository injiceras via konstruktorn
    public DeleteBudgetCommandHandler(IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }


    public async Task<bool> Handle(DeleteBudgetCommand request, CancellationToken cancellationToken)
    {
        // Hämtar budgeten från databasen
        var budget = await _budgetRepository.GetByIdAsync(request.Id);

        // Returnerar false om budgeten inte hittas
        if (budget == null)
            return false;

        // Tar bort budgeten från databasen via repository
        await _budgetRepository.DeleteAsync(request.Id);
        return true;
    }
}
