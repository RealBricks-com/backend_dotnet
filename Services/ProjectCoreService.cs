using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using realbricks_user_dotnet_backend.Data;
using realbricks_user_dotnet_backend.Dtos.ProjectCoreDtos;
using realbricks_user_dotnet_backend.Models;

namespace realbricks_user_dotnet_backend.Services;

public class ProjectCoreService
{
    private readonly RealBricksContext _context;
    private readonly IMapper _mapper;
    public ProjectCoreService(RealBricksContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    // -- methods

    public async Task<IList<ProjectCore>> GetProjects()
    {
        return await _context.ProjectCores
            .Include(p => p.Area)                      
            .Include(p => p.Developer)                 // Navigation property to DeveloperCore class (1 Developer)// Navigation collection to Lead (many Leads)
            .Include(p => p.ProjectAmenities)          // Collection navigation
            .Include(p => p.ProjectLegalDocuments)     // Collection navigation
            .Include(p => p.ProjectMedia)              // Collection navigation
            .Include(p => p.ProjectSpecifications)     // Collection navigation
            .Include(p => p.ProjectUnits)              // Collection navigation
            .ToListAsync();
    }

    public async Task<ProjectCoreDto> GetProject(int ProjectId)
    {
        var result = await _context.ProjectCores
            .Where(p => p.ProjectId == ProjectId)
            .ProjectTo<ProjectCoreDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        return result;
    }


    public async Task<List<ProjectCoreCardDto>> GetProjectCards()
    {
        return await _context.ProjectCores
            .Include(p => p.Developer)
            .Include(p => p.Area)
            .Include(p => p.ProjectMedia)
            .ProjectTo<ProjectCoreCardDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

    }


    public async Task<ProjectFullDto> GetProjectFullDtos(int ProjectId)
    {
        return await _context.ProjectCores
            .Include(p => p.Area)
            .Include(p => p.Developer)
            .Include(p => p.ProjectMedia)
            .Include(p => p.ProjectAmenities)
            .ThenInclude(pa => pa.Amenity) // 🔥 This is critical!
            .Include(p => p.ProjectLegalDocuments)
            .Include(p => p.ProjectSpecifications)
            .Include(p => p.ProjectUnits)
            .Include(p => p.ProjectNearbyLocations)
            .Where(p => p.ProjectId == ProjectId)
            .ProjectTo<ProjectFullDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }
}