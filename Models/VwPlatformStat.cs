using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class VwPlatformStat
{
    public long? TotalUsers { get; set; }

    public long? TotalBuilders { get; set; }

    public long? TotalProjects { get; set; }

    public long? OngoingProjects { get; set; }

    public long? CompletedProjects { get; set; }

    public long? UpcomingProjects { get; set; }

    public long? TotalLeads { get; set; }

    public decimal? TotalRevenue { get; set; }
}
