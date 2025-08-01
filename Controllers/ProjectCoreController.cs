using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using realbricks_user_dotnet_backend.Data;
using realbricks_user_dotnet_backend.Dtos.ProjectCoreDtos;
using realbricks_user_dotnet_backend.Models;
using realbricks_user_dotnet_backend.Services;
using realbricks_user_dotnet_backend.Utilities;

namespace realbricks_user_dotnet_backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProjectCoreController : ControllerBase
{

    private readonly ProjectCoreService _service;
    private readonly RealBricksContext _context;

    public ProjectCoreController(ProjectCoreService service,RealBricksContext context)
    {
        _service = service;
        _context = context;
    }
    
    // methods --
    [HttpGet]
    [ResponseCache(CacheProfileName = "DefaultCache")]
    public async Task<IList<ProjectCore>> GetProjects()
    {
        return await _service.GetProjects();
    }

    [HttpGet("{id:int}")]
    public async Task<ProjectCoreDto> GetProjectDetails(int ProjectId)
    {
        return await _service.GetProject(ProjectId);
    }

    [HttpGet("/pagestest")]
    public async Task<IActionResult> GetProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        if (pageNumber < 1) pageNumber = 1;
        if (pageSize < 1) pageSize = 10;
        
        // get total number of products
        int totalItems = await _context.ProjectCores.CountAsync();
        
        // get the chunk of projects
        var projects = await _context.ProjectCores
            .OrderBy(p => p.ProjectId)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        // package it up
        var result = new PageResult<ProjectCore>
        {
            Items = projects,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalItems = totalItems
        };

        return Ok(result);
    }

}