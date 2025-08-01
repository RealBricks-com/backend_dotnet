using Microsoft.AspNetCore.Mvc;
using realbricks_user_dotnet_backend.Dtos.CountryDto;
using realbricks_user_dotnet_backend.Services;

namespace realbricks_user_dotnet_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountryController : ControllerBase
{
    private readonly CountryService _service;
    public CountryController(CountryService service)
    {
        _service = service;
    }
    
    
    // -- 

    [HttpGet]
    public async Task<IList<CountryReadDto>> GetAllCounties()
    {
        return await _service.GetAllCountries();
    }
    
}