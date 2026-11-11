using MediatR;

namespace BudgetApp.Application.Features.Transactions.Commands;

// Command för att ta bort en transaktion — skickas via MediatR
public class DeleteTransactionCommand : IRequest<bool>
{
    // Id på transaktionen som ska tas bort
    public Guid Id { get; set; }
}
