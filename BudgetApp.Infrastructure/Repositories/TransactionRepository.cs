using BudgetApp.Application.Interfaces;
using BudgetApp.Domain.Entities;
using BudgetApp.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Infrastructure.Repositories;

// TransactionRepository ärver från BaseRepository — får GetByIdAsync, AddAsync, UpdateAsync, DeleteAsync gratis
// Behåller sin egna GetAllByCategoryIdAsync eftersom transaktioner filtreras på CategoryId
public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(AppDbContext context) : base(context)
    {
    }

    // Hämtar alla transaktioner för en specifik kategori
    public async Task<List<Transaction>> GetAllByCategoryIdAsync(Guid categoryId)
    {
        return await _context.Transactions
            .Where(t => t.CategoryId == categoryId)
            .ToListAsync();
    }
}
