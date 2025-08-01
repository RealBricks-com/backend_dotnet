using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class VwInvoiceSummary
{
    public int DeveloperId { get; set; }

    public string DeveloperName { get; set; } = null!;

    public long TotalInvoices { get; set; }

    public decimal? PaidAmount { get; set; }

    public decimal? PendingAmount { get; set; }

    public decimal? OverdueAmount { get; set; }

    public decimal? TotalAmount { get; set; }
}
