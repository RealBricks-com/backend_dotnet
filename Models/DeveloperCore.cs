using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class DeveloperCore
{
    public int DeveloperId { get; set; }

    public string ReraId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<BuilderLeadAction> BuilderLeadActions { get; set; } = new List<BuilderLeadAction>();

    public virtual ICollection<BuilderUser> BuilderUsers { get; set; } = new List<BuilderUser>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Lead> Leads { get; set; } = new List<Lead>();

    public virtual ICollection<ProjectCore> ProjectCores { get; set; } = new List<ProjectCore>();
}
