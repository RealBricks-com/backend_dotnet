using realbricks_user_dotnet_backend.Dtos.AreaDtos;
using realbricks_user_dotnet_backend.Dtos.DeveloperCoreDtos;
using realbricks_user_dotnet_backend.Dtos.ProjectAmenityDtos;
using realbricks_user_dotnet_backend.Dtos.ProjectLegalDocumentDtos;
using realbricks_user_dotnet_backend.Dtos.ProjectMediumDtos;
using realbricks_user_dotnet_backend.Dtos.ProjectNearbyLocationDtos;
using realbricks_user_dotnet_backend.Dtos.ProjectSpecificationDtos;
using realbricks_user_dotnet_backend.Dtos.ProjectUnitDtos;

namespace realbricks_user_dotnet_backend.Dtos.ProjectCoreDtos;

public class ProjectFullDto
{
    public int ProjectId { get; set; }
    public string ReraId { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string? Description { get; set; }
    public string PropertyType { get; set; }
    public decimal MinPrice { get; set; }

    public AreaReadDto Area { get; set; }
    public DeveloperCardReadDto Developer { get; set; }
    public List<ProjectMediumDto> ProjectMedia { get; set; }
    public List<ProjectAmenityReadDto> ProjectAmenities { get; set; }
    public List<ProjectLegalDocumentReadDto> ProjectLegalDocuments { get; set; }
    public List<ProjectSpecificationReadDto> ProjectSpecifications { get; set; }
    public List<ProjectUnitReadDto> ProjectUnits { get; set; }
    public List<ProjectNearbyLocationReadDto> ProjectNearbyLocations { get; set; }
}
