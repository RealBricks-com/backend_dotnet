using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class VwLeadStatusDistribution
{
    public int DeveloperId { get; set; }

    public string DeveloperName { get; set; } = null!;

    public string? LeadStatus { get; set; }

    public long LeadCount { get; set; }

    public decimal EstimatedRevenue { get; set; }
}
