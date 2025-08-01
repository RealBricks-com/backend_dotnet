namespace realbricks_user_dotnet_backend.Dtos.ProjectSpecificationDtos;

public class ProjectSpecificationReadDto
{
    public int SpecificationId { get; set; }
    public int ProjectId { get; set; }
    public string Title { get; set; }
    public string Description  { get; set; }
    public string BrandName { get; set; }
    public string SpecCategory { get; set; }
}