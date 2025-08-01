using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class VwUnitAvailability
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string ReraId { get; set; } = null!;

    public string DeveloperName { get; set; } = null!;

    public string AreaName { get; set; } = null!;

    public string UnitType { get; set; } = null!;

    public int CarpetAreaSqft { get; set; }

    public decimal PriceStarting { get; set; }

    public decimal PriceEnd { get; set; }

    public int UnitsAvailable { get; set; }

    public int Floors { get; set; }

    public decimal? TotalUnits { get; set; }
}
