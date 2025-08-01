using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class ProjectLegalDocument
{
    public int DocumentId { get; set; }

    public int ProjectId { get; set; }

    public string DocumentType { get; set; } = null!;

    public string DocumentUrl { get; set; } = null!;

    public string? VerificationStatus { get; set; }

    public DateTime? UploadedAt { get; set; }

    public DateTime? VerifiedAt { get; set; }

    public string? Remarks { get; set; }

    public virtual ProjectCore Project { get; set; } = null!;
}
