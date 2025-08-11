using Microsoft.AspNetCore.Mvc;
using realbricks_user_dotnet_backend.Dtos.AiSearchDto;
using realbricks_user_dotnet_backend.Dtos.ProjectCoreDtos;
using realbricks_user_dotnet_backend.Utilities;

namespace realbricks_user_dotnet_backend.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AiSearchController : ControllerBase
{
    private readonly AiSearchService _aiSearchService;

    public AiSearchController(AiSearchService aiSearchService)
    {
        _aiSearchService = aiSearchService;
    }

    [HttpPost]
    public async Task<ActionResult<PageResult<ProjectCoreCardDto>>> Post([FromBody] AiSearchRequest request)
    {
        try
        {
            var result = await _aiSearchService.SearchAsync(request);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}