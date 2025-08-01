using Microsoft.AspNetCore.Mvc;
using realbricks_user_dotnet_backend.Dtos.ProjectNearbyLocationDtos;
using realbricks_user_dotnet_backend.Models;
using realbricks_user_dotnet_backend.Services;

namespace realbricks_user_dotnet_backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProjectNearbyLocationController
{
    
    private readonly ProjectNearbyLocationService _service;

    public ProjectNearbyLocationController(ProjectNearbyLocationService service)
    {
        _service = service;
    }

    // methods --
    [HttpGet]
    public async Task<List<ProjectNearbyLocationReadDto>> GetNearbyLocations()
    {
        return await _service.GetNearbyLocations();
    }

    [HttpGet("{project_id:int}")]
    public async Task<ProjectNearbyLocationReadDto> GetProjectNearyByLocationsByProjectId(int ProjectId)
    {
        return await _service.GetProjectNearbyLocationsByProjectId(ProjectId);
    }
    

    
    
}