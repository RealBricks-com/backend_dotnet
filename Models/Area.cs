using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class Area
{
    public int AreaId { get; set; }

    public int SubDistrictId { get; set; }

    public string Name { get; set; } = null!;

    public string? Pincode { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<ProjectCore> ProjectCores { get; set; } = new List<ProjectCore>();

    public virtual SubDistrict SubDistrict { get; set; } = null!;
}
