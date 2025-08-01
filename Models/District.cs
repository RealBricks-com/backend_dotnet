using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class District
{
    public int DistrictId { get; set; }

    public int CityId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<SubDistrict> SubDistricts { get; set; } = new List<SubDistrict>();
}
