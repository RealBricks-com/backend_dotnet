using realbricks_user_dotnet_backend.Dtos.AmenityDtos;

namespace realbricks_user_dotnet_backend.Dtos.ProjectAmenityDtos;

public class ProjectAmenityReadDto
{
    public int ProjectId { get; set; }
    public AmenityReadDto Amenity { get; set; }
    
}