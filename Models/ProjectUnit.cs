using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class ProjectUnit
{
    public int UnitId { get; set; }

    public int ProjectId { get; set; }

    public string UnitType { get; set; } = null!;

    public int CarpetAreaSqft { get; set; }

    public decimal PriceStarting { get; set; }

    public decimal PriceEnd { get; set; }

    public int UnitsAvailable { get; set; }

    public int Floors { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ProjectCore Project { get; set; } = null!;
}
