using BudgetApp.Application.Features.Transactions.DTOs;
using MediatR;

namespace BudgetApp.Application.Features.Transactions.Queries;

// Query för att hämta alla transaktioner för en specifik kategori och vecka — skickas via MediatR
public class GetTransactionsByWeekQuery : IRequest<List<TransactionDto>>
{
    // Id på kategorin vars transaktioner ska hämtas
    public Guid CategoryId { get; set; }

    // År och veckonummer — används för att filtrera transaktioner på rätt vecka
    public int Year { get; set; }
    public int WeekNumber { get; set; }
}
