using BudgetApp.Application.Features.Transactions.DTOs;
using MediatR;

namespace BudgetApp.Application.Features.Transactions.Queries;

// Query för att hämta en specifik transaktion baserat på Id — skickas via MediatR
public class GetTransactionByIdQuery : IRequest<TransactionDto?>
{
    // Id på transaktionen som ska hämtas
    public Guid Id { get; set; }
}
