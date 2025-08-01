namespace realbricks_user_dotnet_backend.Models;

public class ProjectNearbyLocation
{
    public int LocationId { get; set; }
    public int ProjectId { get; set; }

    public string LocationType { get; set; } // Enum in DB, map to string or C# enum
    public string Name { get; set; }
    public decimal DistanceKm { get; set; }
    public string? Address { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation property
    public virtual ProjectCore Project { get; set; }
}