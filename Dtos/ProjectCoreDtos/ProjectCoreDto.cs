using realbricks_user_dotnet_backend.Dtos.DeveloperCoreDtos;
using realbricks_user_dotnet_backend.Dtos.ProjectMediumDtos;

namespace realbricks_user_dotnet_backend.Dtos.ProjectCoreDtos;

public class ProjectCoreDto
{
    public int ProjectId { get; set; }
    public string ReraId { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public int DeveloperId { get; set; }
    public int AreaId { get; set; }
    public string PropertyType { get; set; }
    public int CarpetAreaSqft { get; set; }
    public decimal MinPrice { get; set; }
    public string Status { get; set; }
    public List<ProjectMediumDto> ProjectMedia { get; set; }    
    public DeveloperCardReadDto DeveloperCardReadDtoRefernce { get; set; }
    
}