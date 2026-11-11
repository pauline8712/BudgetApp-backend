using BudgetApp.Application.Interfaces;
using MediatR;

namespace BudgetApp.Application.Features.Transactions.Commands;

// Hanterar DeleteTransactionCommand — tar bort en transaktion och återställer Category.CurrentBalance
public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, bool>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly ICategoryRepository _categoryRepository;

    // Både ITransactionRepository och ICategoryRepository injiceras via konstruktorn
    public DeleteTransactionCommandHandler(
        ITransactionRepository transactionRepository,
        ICategoryRepository categoryRepository)
    {
        _transactionRepository = transactionRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<bool> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
    {
        // Hämtar transaktionen från databasen
        var transaction = await _transactionRepository.GetByIdAsync(request.Id);

        // Returnerar false om transaktionen inte hittas
        if (transaction == null)
            return false;

        // Hämtar kategorin för att återställa CurrentBalance
        var category = await _categoryRepository.GetByIdAsync(transaction.CategoryId);

        // Kastar ett undantag om kategorin inte hittas
        if (category == null)
            throw new Exception($"Category with id {transaction.CategoryId} not found");

        // Återställer beloppets effekt på CurrentBalance
        if (transaction.Type == "Expense")
            category.CurrentBalance += transaction.Amount;
        else if (transaction.Type == "Income")
            category.CurrentBalance -= transaction.Amount;

        // Sparar återställt saldo i databasen
        await _categoryRepository.UpdateAsync(category);

        // Tar bort transaktionen från databasen
        await _transactionRepository.DeleteAsync(request.Id);
        return true;
    }
}
