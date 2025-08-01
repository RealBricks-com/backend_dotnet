using Microsoft.EntityFrameworkCore;
using realbricks_user_dotnet_backend.Data;
using realbricks_user_dotnet_backend.Dtos.CountryDto;

namespace realbricks_user_dotnet_backend.Services;

public class CountryService
{
    private readonly RealBricksContext _context;

    public CountryService(RealBricksContext context)
    {
        _context = context;
    }
    
    
    // -- methods
    public async Task<IList<CountryReadDto>> GetAllCountries()
    {
        return await _context.Countries.Select(row => new CountryReadDto
        {
            CountryId = row.CountryId,
            Name = row.Name
        }).ToListAsync();
    }
    
}