using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using realbricks_user_dotnet_backend.Data;
using realbricks_user_dotnet_backend.Dtos.AmenityDtos;
using realbricks_user_dotnet_backend.Models;

namespace realbricks_user_dotnet_backend.Services;

public class AmenityService
{

    private readonly RealBricksContext _context;
    private readonly  IMapper _mapper;
    public AmenityService(RealBricksContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    // -- 

    [HttpGet]
    public IList<AmenityReadDto> GetAmentities()
    {
        return _context.Amenities.Select(row => new AmenityReadDto
            { AmenityId = row.AmenityId, Description = row.Description, Name = row.Name }).ToList();
    }

    [HttpGet("{amenityId:int}")]
    public async Task<AmenityReadDto> GetAmenity(int amenityId)
    {
        return await _context.Amenities.Where(row => row.AmenityId == amenityId)
            .ProjectTo<AmenityReadDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }

}