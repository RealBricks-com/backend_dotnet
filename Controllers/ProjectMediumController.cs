using Microsoft.AspNetCore.Mvc;
using realbricks_user_dotnet_backend.Dtos.ProjectMediumDtos;
using realbricks_user_dotnet_backend.Services;

namespace realbricks_user_dotnet_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectMediumController
{
    private readonly ProjectMediumService _service;
    public ProjectMediumController(ProjectMediumService service)
    {
        _service = service;
    }
    
    // methods
    [HttpGet("{project_id:int}")]
    public async Task<List<ProjectMediumDto>> GetProjectMedia(int project_id)
    {
        return await _service.GetProjectMedia(project_id);
    }
    
}