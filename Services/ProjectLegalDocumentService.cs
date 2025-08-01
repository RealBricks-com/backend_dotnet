using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using realbricks_user_dotnet_backend.Data;
using realbricks_user_dotnet_backend.Dtos.ProjectLegalDocumentDtos;
using realbricks_user_dotnet_backend.Models;

namespace realbricks_user_dotnet_backend.Services;

public class ProjectLegalDocumentService
{
    private readonly RealBricksContext _context;
    private readonly  IMapper _mapper;

    public ProjectLegalDocumentService(RealBricksContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    
    // methods

    public async Task<List<ProjectLegalDocumentReadDto>> GetProjectLegalDocuments()
    {
        return await _context.ProjectLegalDocuments
            .ProjectTo<ProjectLegalDocumentReadDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }


    public async Task<List<ProjectLegalDocumentReadDto>> GetProjectLegalDocumentByProjectId(int ProjectId)
    {
        return await _context.ProjectLegalDocuments.Where(p => p.ProjectId == ProjectId)
            .ProjectTo<ProjectLegalDocumentReadDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
    
}