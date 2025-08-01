using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class EmailEvent
{
    public int EventId { get; set; }

    public int LeadId { get; set; }

    public string EmailType { get; set; } = null!;

    public string RecipientEmail { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Body { get; set; } = null!;

    public string? Status { get; set; }

    public int? RetryCount { get; set; }

    public string? ErrorMessage { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Lead Lead { get; set; } = null!;
}
