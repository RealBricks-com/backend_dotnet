using Microsoft.EntityFrameworkCore;
using realbricks_user_dotnet_backend.Data;
using realbricks_user_dotnet_backend.Models;

namespace realbricks_user_dotnet_backend.Services;

public class VwUnitAvailabilityService
{
    private readonly RealBricksContext _context;

    public VwUnitAvailabilityService(RealBricksContext context)
    {
        _context = context;
    }
    
    // method --

    public async Task<VwUnitAvailability> GetProjectAvailability(int ProjectId)
    {
        return await _context.VwUnitAvailabilities.FirstOrDefaultAsync(record => record.ProjectId == ProjectId);
    }
}