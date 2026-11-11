using BudgetApp.Application.Features.Transactions.DTOs;
using MediatR;

namespace BudgetApp.Application.Features.Transactions.Commands;

// Command för att uppdatera en befintlig transaktion — skickas via MediatR
public class UpdateTransactionCommand : IRequest<TransactionDto>
{
    // Id på transaktionen som ska uppdateras — sätts från URL-parametern i controllern
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
