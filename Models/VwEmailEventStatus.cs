using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class VwEmailEventStatus
{
    public string EmailType { get; set; } = null!;

    public string? Status { get; set; }

    public long EventCount { get; set; }

    public long FailedCount { get; set; }

    public decimal? AvgRetryCount { get; set; }
}
