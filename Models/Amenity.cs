using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class Amenity
{
    public int AmenityId { get; set; }

    public string Name { get; set; } = null!;

    public string? Category { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<ProjectAmenity> ProjectAmenities { get; set; } = new List<ProjectAmenity>();
}
