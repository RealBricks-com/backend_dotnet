using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class AdminUser
{
    public int AdminId { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Role { get; set; }

    public DateTime? CreatedAt { get; set; }
}
