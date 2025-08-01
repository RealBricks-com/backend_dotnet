using Microsoft.AspNetCore.Mvc;
using realbricks_user_dotnet_backend.Dtos.AmenityDtos;
using realbricks_user_dotnet_backend.Services;

namespace realbricks_user_dotnet_backend.Controllers;


[ApiController]
[Route("/api/amenities")]
public class AmenityController
{
    
    // context
    private readonly AmenityService _service;
    public AmenityController(AmenityService service)
    {
        _service = service;
    }
    
    // -- methods

    [HttpGet]
    public IList<AmenityReadDto> GetAmenities()
    {
        return _service.GetAmentities();
    }

    [HttpGet("{amenityId:int}")]
    public async Task<AmenityReadDto> GetAmenity(int amenityId)
    {
        return await _service.GetAmenity(amenityId);
    }

}