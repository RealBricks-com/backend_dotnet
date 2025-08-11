using Microsoft.AspNetCore.Mvc;
using realbricks_user_dotnet_backend.Dtos.LeadDtos;
using realbricks_user_dotnet_backend.Models;
using realbricks_user_dotnet_backend.Services;

namespace realbricks_user_dotnet_backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class LeadController : ControllerBase
{
    
    private readonly LeadService _leadService;

    public LeadController(LeadService leadService)
    {
        _leadService = leadService;
    }
    
    // action methods

    [HttpPost("sendenquiry")]
    public async Task<ActionResult<LeadResponseDto>> SendEnquiry([FromBody] LeadCreateDto leadDto)
    {
        var response = await _leadService.SendEnquiry(leadDto);
        return Ok(response);
    }
    
    
}