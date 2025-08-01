using Microsoft.AspNetCore.Mvc;
using realbricks_user_dotnet_backend.Dtos.AreaDtos;
using realbricks_user_dotnet_backend.Models;
using realbricks_user_dotnet_backend.Services;

namespace realbricks_user_dotnet_backend.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AreaController : ControllerBase
{
    private readonly AreaService _service;

    public AreaController(AreaService service)
    {
        _service = service;
    }
    
    // actions

    [HttpGet]
    public IList<AreaReadDto> GetAreas()
    {
        return _service.GetAreas();
    }

    [HttpGet("{areaId:int}")]
    public async Task<AreaReadDto> GetAreaById(int areaId)
    {
        return await _service.GetArea(areaId);
    }
}