using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class VwProjectSummary
{
    public int ProjectId { get; set; }

    public string ReraId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public decimal MinPrice { get; set; }

    public int? CarpetAreaSqft { get; set; }

    public string? Status { get; set; }

    public string DeveloperName { get; set; } = null!;

    public string AreaName { get; set; } = null!;

    public string CityName { get; set; } = null!;

    public string StateName { get; set; } = null!;

    public long LeadsCount { get; set; }
}
