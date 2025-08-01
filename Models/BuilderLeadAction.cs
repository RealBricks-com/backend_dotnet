using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class BuilderLeadAction
{
    public int ActionId { get; set; }

    public int LeadId { get; set; }

    public int DeveloperId { get; set; }

    public string ActionType { get; set; } = null!;

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual DeveloperCore Developer { get; set; } = null!;

    public virtual Lead Lead { get; set; } = null!;
}
