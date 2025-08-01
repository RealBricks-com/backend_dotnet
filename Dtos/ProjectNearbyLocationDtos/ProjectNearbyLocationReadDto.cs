namespace realbricks_user_dotnet_backend.Dtos.ProjectNearbyLocationDtos;

public class ProjectNearbyLocationReadDto
{
    public int LocationId { get; set; }
    public int ProjectId { get; set; }
    public string LocationType {get; set;}
    public string Name { get; set; }
    public decimal DistanceKm { get; set; }
    public string Address { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
}