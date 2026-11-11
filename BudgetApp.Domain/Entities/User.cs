using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = "User"; // Default role is "User"
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // En användare kan ha flera budgetar — en per månad och år
    public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
}
