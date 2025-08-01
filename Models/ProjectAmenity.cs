using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class ProjectAmenity
{
    public int ProjectId { get; set; }

    public int AmenityId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Amenity Amenity { get; set; } = null!;

    public virtual ProjectCore Project { get; set; } = null!;
}
