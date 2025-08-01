using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class ProjectMedium
{
    public int MediaId { get; set; }

    public int ProjectId { get; set; }

    public string FileUrl { get; set; } = null!;

    public string? MediaType { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ProjectCore Project { get; set; } = null!;
}
