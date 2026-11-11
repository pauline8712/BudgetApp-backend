using BudgetApp.Domain.Entities;

namespace BudgetApp.Application.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync(Guid budgetId);
    Task<Category?> GetByIdAsync(Guid id);
    Task<Category> AddAsync(Category category);
    Task<Category> UpdateAsync(Category category);
    Task DeleteAsync(Guid id);
}
