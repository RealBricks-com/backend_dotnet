using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<State> States { get; set; } = new List<State>();
}
