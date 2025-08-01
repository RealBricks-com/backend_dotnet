using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class BuilderUser
{
    public int BuilderUserId { get; set; }

    public int DeveloperId { get; set; }

    public string ReraId { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual DeveloperCore Developer { get; set; } = null!;
}
