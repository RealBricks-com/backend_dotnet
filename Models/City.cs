using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class City
{
    public int CityId { get; set; }

    public int StateId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<District> Districts { get; set; } = new List<District>();

    public virtual State State { get; set; } = null!;
}
