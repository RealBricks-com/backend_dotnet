using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class VwRecentEnquiry
{
    public int LeadId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string? ProjectName { get; set; }

    public string DeveloperName { get; set; } = null!;
}
