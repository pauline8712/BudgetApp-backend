using BudgetApp.Application.Interfaces;
using MediatR;

namespace BudgetApp.Application.Features.Users.Commands;

// Hanterar DeleteUserCommand — tar bort en användare från databasen
public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        // Hämtar användaren från databasen
        var user = await _userRepository.GetByIdAsync(request.Id);

        // Returnerar false om användaren inte hittas
        if (user == null)
            return false;

        // Tar bort användaren från databasen via repository
        await _userRepository.DeleteAsync(request.Id);
        return true;
    }
}
