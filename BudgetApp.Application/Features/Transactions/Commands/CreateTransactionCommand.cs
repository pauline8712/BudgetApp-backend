using BudgetApp.Application.Features.Transactions.DTOs;
using MediatR;

namespace BudgetApp.Application.Features.Transactions.Commands;

public class CreateTransactionCommand : IRequest<TransactionDto>
{
    public Guid CategoryId { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
