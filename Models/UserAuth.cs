using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class UserAuth
{
    public int UserId { get; set; }

    public string? Email { get; set; }

    public string? GoogleId { get; set; }

    public string? FirstName { get; set; }

    public string? Phone { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Lead> Leads { get; set; } = new List<Lead>();
}
