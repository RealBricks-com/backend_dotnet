using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class VwLeadBillingSummary
{
    public int DeveloperId { get; set; }

    public string ReraId { get; set; } = null!;

    public string DeveloperName { get; set; } = null!;

    public long TotalLeads { get; set; }

    public decimal TotalRevenue { get; set; }
}
