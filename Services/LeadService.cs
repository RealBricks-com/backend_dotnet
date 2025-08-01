using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using realbricks_user_dotnet_backend.Data;
using realbricks_user_dotnet_backend.Dtos.LeadDtos;
using realbricks_user_dotnet_backend.Models;

namespace realbricks_user_dotnet_backend.Services;

public class LeadService
{
    private readonly RealBricksContext _context;
    private readonly IMapper _mapper;

    public LeadService(RealBricksContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    
    // -- methods

    public async Task<LeadResponseDto> SendEnquiry(LeadCreateDto leadDto)
    {
        
        var entity = _mapper.Map<Lead>(leadDto);
        entity.CreatedAt = DateTime.UtcNow;
        
        _context.Leads.Add(entity);
        await _context.SaveChangesAsync();

        return new LeadResponseDto{
            Message = "Enquiry Sent Successfully",
            LeadId = entity.LeadId,
            Status = true
        };
    }
}