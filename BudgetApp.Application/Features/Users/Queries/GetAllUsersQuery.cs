using BudgetApp.Application.Features.Users.DTOs;
using MediatR;

namespace BudgetApp.Application.Features.Users.Queries;

// Query för att hämta alla användare
public class GetAllUsersQuery : IRequest<List<UserDto>>
{
}
