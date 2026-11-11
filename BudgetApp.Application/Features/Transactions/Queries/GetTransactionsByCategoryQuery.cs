using BudgetApp.Application.Features.Transactions.DTOs;
using MediatR;

namespace BudgetApp.Application.Features.Transactions.Queries;

// Query för att hämta alla transaktioner för en specifik kategori — skickas via MediatR
public class GetTransactionsByCategoryQuery : IRequest<List<TransactionDto>>
{
    // Id på kategorin vars transaktioner ska hämtas
    public Guid CategoryId { get; set; }
}
