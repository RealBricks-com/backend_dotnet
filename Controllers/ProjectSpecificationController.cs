using Microsoft.AspNetCore.Mvc;
using realbricks_user_dotnet_backend.Dtos.ProjectSpecificationDtos;
using realbricks_user_dotnet_backend.Services;

namespace realbricks_user_dotnet_backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProjectSpecificationController
{

    private readonly ProjectSpecificationService _service;

    public ProjectSpecificationController(ProjectSpecificationService service)
    {
        _service = service;
    }
    
    // methods --

    [HttpGet("{ProjectId:int}")]
    public async Task<List<ProjectSpecificationReadDto>> GetProjectSpecificationByProjectId(int ProjectId)
    {
        return await _service.GetProjectSpecificationByProjectId(ProjectId);
    }
    

}