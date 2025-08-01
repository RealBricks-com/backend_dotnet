using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using realbricks_user_dotnet_backend.Data;
using realbricks_user_dotnet_backend.Dtos.ProjectMediumDtos;

namespace realbricks_user_dotnet_backend.Services;

public class ProjectMediumService
{
    private readonly RealBricksContext _context;
    private readonly IMapper _mapper;

    public ProjectMediumService(RealBricksContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    // -- methods

    public async Task<List<ProjectMediumDto>> GetProjectMedia(int ProjectId)
    {
        return await _context.ProjectMedia
            .Where(record => record.ProjectId == ProjectId)
            .ProjectTo<ProjectMediumDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}