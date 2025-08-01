using Microsoft.AspNetCore.Mvc;
using realbricks_user_dotnet_backend.Dtos.DeveloperCoreDtos;
using realbricks_user_dotnet_backend.Services;

namespace realbricks_user_dotnet_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeveloperCoreController : ControllerBase
{
    private readonly DeveloperService _service;
    public DeveloperCoreController(DeveloperService service)
    {
        _service = service;
    }
    
    // -- methods

    [HttpGet]
    public async Task<List<DeveloperCoreReadDto>> GetAllDevelopers()
    {
        return await _service.GetAllDevelopers();
    }
    
    
    [HttpGet("/id/{id:int}")]
    public async Task<DeveloperCoreReadDto> GetDeveloperById(int id)
    {
        return await _service.GetDeveloperById(id);
    }

    [HttpGet("/rera_id/{rera_id}")]
    public async Task<DeveloperCoreReadDto> GetDeveloperByReraId(string reraId)
    {
        return await _service.GetDeveloperCardByReraId(reraId);
    }
    
    [HttpGet("/name/{developer_name}")]
    public async Task<DeveloperCoreReadDto> GetDeveloperByName(string developerName)
    {
        return await _service.GetDeveloperByName(developerName);
    }
    
    
    
}