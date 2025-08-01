using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class VwProjectDetail
{
    public int ProjectId { get; set; }

    public string ReraId { get; set; } = null!;

    public string ProjectName { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Description { get; set; }

    public string PropertyType { get; set; } = null!;

    public int? CarpetAreaSqft { get; set; }

    public decimal MinPrice { get; set; }

    public string? Status { get; set; }

    public string DeveloperName { get; set; } = null!;

    public string AreaName { get; set; } = null!;

    public string SubDistrictName { get; set; } = null!;

    public string DistrictName { get; set; } = null!;

    public string CityName { get; set; } = null!;

    public string StateName { get; set; } = null!;

    public string? Amenities { get; set; }

    public string? MediaUrls { get; set; }

    public string? LegalDocuments { get; set; }

    public string? DocumentUrls { get; set; }

    public string? UnitTypes { get; set; }

    public decimal? TotalUnitsAvailable { get; set; }

    public int? MaxFloors { get; set; }
}
