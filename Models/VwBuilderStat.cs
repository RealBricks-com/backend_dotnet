using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class VwBuilderStat
{
    public int BuilderUserId { get; set; }

    public string ReraId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string DeveloperName { get; set; } = null!;

    public long ProjectCount { get; set; }

    public long EnquiryCount { get; set; }

    public decimal TotalRevenue { get; set; }
}
