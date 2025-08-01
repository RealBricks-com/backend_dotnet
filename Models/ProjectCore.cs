using System;
using System.Collections.Generic;

namespace realbricks_user_dotnet_backend.Models;

public partial class ProjectCore
{
    public int ProjectId { get; set; }

    public string ReraId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Description { get; set; }

    public int DeveloperId { get; set; }

    public int AreaId { get; set; }

    public string PropertyType { get; set; } = null!;

    public int? CarpetAreaSqft { get; set; }

    public decimal MinPrice { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Area Area { get; set; } = null!;

    public virtual DeveloperCore Developer { get; set; } = null!;

    public virtual ICollection<Lead> Leads { get; set; } = new List<Lead>();

    public virtual ICollection<ProjectAmenity> ProjectAmenities { get; set; } = new List<ProjectAmenity>();

    public virtual ICollection<ProjectLegalDocument> ProjectLegalDocuments { get; set; } = new List<ProjectLegalDocument>();

    public virtual ICollection<ProjectMedium> ProjectMedia { get; set; } = new List<ProjectMedium>();

    public virtual ICollection<ProjectSpecification> ProjectSpecifications { get; set; } = new List<ProjectSpecification>();

    public virtual ICollection<ProjectUnit> ProjectUnits { get; set; } = new List<ProjectUnit>();
    
    public virtual ICollection<ProjectNearbyLocation> ProjectNearbyLocations { get; set; } = new List<ProjectNearbyLocation>();

    
}
