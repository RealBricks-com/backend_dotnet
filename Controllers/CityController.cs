using Microsoft.AspNetCore.Mvc;
using realbricks_user_dotnet_backend.Dtos.CityDto;
using realbricks_user_dotnet_backend.Services;

namespace realbricks_user_dotnet_backend.Controllers;

public class CityController : ControllerBase
{
    private readonly CityService _cityService;

    public CityController(CityService cityService)
    {
        _cityService = cityService;
    }
    
    // -- actions

    [HttpGet]
    public IList<CityReadDto> GetCities()
    {
       return _cityService.GetCities();
    }
    
}