using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using realbricks_user_dotnet_backend.Data;
using realbricks_user_dotnet_backend.Dtos.AreaDtos;
using realbricks_user_dotnet_backend.Models;

namespace realbricks_user_dotnet_backend.Services;

public class AreaService
{
    private readonly RealBricksContext _context;
    private readonly IMapper _mapper;

    public AreaService(RealBricksContext context,IMapper mapper)
    {
        _context = context;
        _mapper =  mapper;
    }
    
    // -- actions
    
    public IList<AreaReadDto> GetAreas()
    {
        return _context.Areas.Select(row => new AreaReadDto
        {
            AreaId = row.AreaId, Name = row.Name, PinCode = row.Pincode, SubDistrictId = row.SubDistrictId.ToString()
        }).ToList();
    }
    
    public async Task<AreaReadDto> GetArea(int areaId)
    {
        return await _context.Areas.Where(row => row.AreaId == areaId)
            .ProjectTo<AreaReadDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }
}