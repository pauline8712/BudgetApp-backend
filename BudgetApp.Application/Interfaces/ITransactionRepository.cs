using BudgetApp.Domain.Entities;

namespace BudgetApp.Application.Interfaces;

public interface ITransactionRepository
{
    Task<List<Transaction>> GetAllByCategoryIdAsync(Guid categoryId);
    Task<Transaction?> GetByIdAsync(Guid id);
    Task<Transaction> AddAsync(Transaction transaction);
    Task<Transaction> UpdateAsync(Transaction transaction);
    Task DeleteAsync(Guid id);
}
