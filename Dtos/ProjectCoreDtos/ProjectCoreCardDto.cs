using realbricks_user_dotnet_backend.Dtos.AreaDtos;
using realbricks_user_dotnet_backend.Dtos.DeveloperCoreDtos;
using realbricks_user_dotnet_backend.Dtos.ProjectMediumDtos;

namespace realbricks_user_dotnet_backend.Dtos.ProjectCoreDtos;

public class ProjectCoreCardDto
{
    public int ProjectId { get; set; }
    public string ReraId { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public DeveloperCardReadDto DeveloperCard { get; set; }
    public int AreaId { get; set; }
    public string PropertyType { get; set; }
    public decimal MinPrice { get; set; }
    public AreaReadDto Area { get; set; }
    public List<ProjectMediumDto> ProjectMedium { get; set; }
}