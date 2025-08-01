using AutoMapper;
using Microsoft.EntityFrameworkCore;
using realbricks_user_dotnet_backend.Data;
using realbricks_user_dotnet_backend.Dtos.DeveloperCoreDtos;

namespace realbricks_user_dotnet_backend.Services;

public class DeveloperService
{
    private readonly RealBricksContext _context;
    private readonly IMapper _mapper;

    public DeveloperService(RealBricksContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    // -- methods
    
    
    public async Task<List<DeveloperCoreReadDto>> GetAllDevelopers()
    {
        var developers = await _context.DeveloperCores.ToListAsync();
        return _mapper.Map<List<DeveloperCoreReadDto>>(developers);
    }

    public async Task<DeveloperCoreReadDto> GetDeveloperById(int id)
    {
        var developer = await _context.DeveloperCores.FindAsync(id);
        return _mapper.Map<DeveloperCoreReadDto>(developer);
    }

    public async Task<DeveloperCoreReadDto> GetDeveloperByName(string name)
    {
        var developer = await _context.DeveloperCores.FirstOrDefaultAsync(d => d.Name == name);
        return _mapper.Map<DeveloperCoreReadDto>(developer);
    }

    public async Task<DeveloperCoreReadDto> GetDeveloperCardByReraId(string ReraId)
    {
        var developer = await _context.DeveloperCores.FirstOrDefaultAsync(d => d.ReraId == ReraId);
        return _mapper.Map<DeveloperCoreReadDto>(developer);
    }
    
    
    
    
}