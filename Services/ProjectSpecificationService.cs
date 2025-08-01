using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using realbricks_user_dotnet_backend.Data;
using realbricks_user_dotnet_backend.Dtos.ProjectSpecificationDtos;
using realbricks_user_dotnet_backend.Models;

namespace realbricks_user_dotnet_backend.Services;

public class ProjectSpecificationService
{
    private readonly RealBricksContext _context;
    private readonly IMapper _mapper;

    public ProjectSpecificationService(RealBricksContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    // methods --

    public async Task<List<ProjectSpecificationReadDto>> GetProjectSpecifications()
    {
        return await _context.ProjectLegalDocuments
            .ProjectTo<ProjectSpecificationReadDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<List<ProjectSpecificationReadDto>> GetProjectSpecificationByProjectId(int ProjectId)
    {
        return await _context.ProjectSpecifications
            .Where(record => record.ProjectId == ProjectId)
            .ProjectTo<ProjectSpecificationReadDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
    
}