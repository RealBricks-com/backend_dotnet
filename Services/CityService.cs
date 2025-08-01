using realbricks_user_dotnet_backend.Data;
using realbricks_user_dotnet_backend.Dtos.CityDto;

namespace realbricks_user_dotnet_backend.Services;

public class CityService
{
    private readonly RealBricksContext _context;
    public CityService(RealBricksContext context)
    {
        _context = context;
    }
    
    
    // -- methods
    public IList<CityReadDto> GetCities()
    {
        return _context.Cities.Select(row=>
            new CityReadDto
            {
                CityId = row.CityId,
                Name = row.Name,
                StateId = row.StateId
            }
            ).ToList();
    }
    
}