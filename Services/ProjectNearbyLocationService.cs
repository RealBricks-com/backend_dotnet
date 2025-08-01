using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using realbricks_user_dotnet_backend.Data;
using realbricks_user_dotnet_backend.Dtos.ProjectNearbyLocationDtos;
using realbricks_user_dotnet_backend.Models;

namespace realbricks_user_dotnet_backend.Services;

public class ProjectNearbyLocationService
{
    private readonly RealBricksContext _context;
    private readonly IMapper _mapper;

    public ProjectNearbyLocationService(RealBricksContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ProjectNearbyLocationReadDto>> GetNearbyLocations(int? projectId = null)
    {
        var query = _context.ProjectNearbyLocations.AsQueryable();
        if (projectId.HasValue)
        {
            query = query.Where(x => x.ProjectId == projectId);
        }
        return await query
            .ProjectTo<ProjectNearbyLocationReadDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }


    public async Task<ProjectNearbyLocationReadDto> GetProjectNearbyLocationsByProjectId(int ProjectId)
    {
        return await _context.ProjectNearbyLocations
            .Where(record => record.ProjectId == ProjectId)
            .ProjectTo<ProjectNearbyLocationReadDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }
}