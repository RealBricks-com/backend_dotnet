using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using realbricks_user_dotnet_backend.Data;
using realbricks_user_dotnet_backend.Models;
using realbricks_user_dotnet_backend.Services;

namespace realbricks_user_dotnet_backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TestViewController
{
    private readonly TestViewService _service;

    public TestViewController(TestViewService service)
    {
        _service = service;
    }


    [HttpGet("{project_id:int}")]
    public async Task<VwProjectDetail> GetProjectDetail(int project_id)
    {
        return await _service.GetProjectSummary(project_id);
    }
    
}