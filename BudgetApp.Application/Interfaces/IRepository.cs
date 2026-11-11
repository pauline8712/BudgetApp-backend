namespace BudgetApp.Application.Interfaces;

// Generiskt repository-interface — bas för alla repositories i appen
// Innehåller gemensamma CRUD-metoder som är identiska i alla repositories
public interface IRepository<T> where T : class
{
    // Hämtar en specifik entitet baserat på Id
    Task<T?> GetByIdAsync(Guid id);

    // Lägger till en ny entitet i databasen
    Task<T> AddAsync(T entity);

    // Uppdaterar en befintlig entitet i databasen
    Task<T> UpdateAsync(T entity);

    // Tar bort en entitet baserat på Id
    Task DeleteAsync(Guid id);
}
