using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class VwLegalDocumentStatus
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string ReraId { get; set; } = null!;

    public string DeveloperName { get; set; } = null!;

    public string DocumentType { get; set; } = null!;

    public string DocumentUrl { get; set; } = null!;

    public string? VerificationStatus { get; set; }

    public DateTime? UploadedAt { get; set; }

    public DateTime? VerifiedAt { get; set; }

    public string? Remarks { get; set; }
}
