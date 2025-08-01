using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class VwUserStat
{
    public int UserId { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public long EnquiryCount { get; set; }
}
