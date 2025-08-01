using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using realbricks_user_dotnet_backend.Data;
using realbricks_user_dotnet_backend.Models;

namespace realbricks_user_dotnet_backend.Services;

public class TestViewService
{
    private readonly RealBricksContext _context;
    private readonly IMapper _mapper;

    public TestViewService(RealBricksContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<VwProjectDetail> GetProjectSummary(int ProjectId)
    {
        return await _context.VwProjectDetails
            .FirstOrDefaultAsync(record => record.ProjectId == ProjectId);
    }
    
}