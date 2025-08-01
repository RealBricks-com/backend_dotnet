using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int DeveloperId { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public string? PaymentStatus { get; set; }

    public DateOnly DueDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual DeveloperCore Developer { get; set; } = null!;
}
