using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class AuditLog
{
    public int LogId { get; set; }

    public int UserId { get; set; }

    public string UserType { get; set; } = null!;

    public string EventType { get; set; } = null!;

    public DateTime? EventTime { get; set; }
}
