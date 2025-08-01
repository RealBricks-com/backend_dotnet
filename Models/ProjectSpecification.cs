using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class ProjectSpecification
{
    public int SpecificationId { get; set; }

    public int ProjectId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? BrandName { get; set; }

    public int? DisplayOrder { get; set; }

    public string SpecCategory { get; set; } = null!;

    public string SpecName { get; set; } = null!;

    public string SpecValue { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ProjectCore Project { get; set; } = null!;
}
