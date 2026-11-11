using BudgetApp.Application.Interfaces;
using BudgetApp.Domain.Entities;
using BudgetApp.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Infrastructure.Repositories;

// CategoryRepository ärver från BaseRepository — får GetByIdAsync, AddAsync, UpdateAsync, DeleteAsync gratis
// Behåller sin egna GetAllAsync eftersom kategorier filtreras på BudgetId
public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    // Hämtar alla kategorier för en specifik budget
    public async Task<List<Category>> GetAllAsync(Guid budgetId)
    {
        return await _context.Categories
            .Where(c => c.BudgetId == budgetId)
            .ToListAsync();
    }
}
