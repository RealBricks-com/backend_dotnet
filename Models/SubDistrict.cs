using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class SubDistrict
{
    public int SubDistrictId { get; set; }

    public int DistrictId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();

    public virtual District District { get; set; } = null!;
}
