using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class Lead
{
    public int LeadId { get; set; }

    public int? ProjectId { get; set; }

    public int DeveloperId { get; set; }

    public int? UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public decimal? BudgetMin { get; set; }

    public decimal? BudgetMax { get; set; }

    public string? LeadStatus { get; set; }

    public int? LeadScore { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<BuilderLeadAction> BuilderLeadActions { get; set; } = new List<BuilderLeadAction>();

    public virtual DeveloperCore Developer { get; set; } = null!;

    public virtual ICollection<EmailEvent> EmailEvents { get; set; } = new List<EmailEvent>();

    public virtual ProjectCore? Project { get; set; }

    public virtual UserAuth? User { get; set; }
}
