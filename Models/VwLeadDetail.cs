using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class VwLeadDetail
{
    public int LeadId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? LeadStatus { get; set; }

    public int? LeadScore { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? ProjectName { get; set; }

    public string? ProjectReraId { get; set; }

    public string DeveloperName { get; set; } = null!;

    public string DeveloperReraId { get; set; } = null!;
}
