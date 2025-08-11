using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using realbricks_user_dotnet_backend.Data;
using realbricks_user_dotnet_backend.Dtos.AiSearchDto;
using realbricks_user_dotnet_backend.Dtos.ProjectCoreDtos;
using realbricks_user_dotnet_backend.Utilities;
using realbricks_user_dotnet_backend.Models;

public class AiSearchService
{
    private readonly HttpClient _httpClient;
    private readonly RealBricksContext _context;
    private readonly IMapper _mapper;

    public AiSearchService(HttpClient httpClient, RealBricksContext context, IMapper mapper)
    {
        _httpClient = httpClient;
        _context = context;
        _mapper = mapper;
    }

    public async Task<PageResult<ProjectCoreCardDto>> SearchAsync(AiSearchRequest request)
    {
        // Send query to FastAPI
        var fastApiResponse = await _httpClient.PostAsJsonAsync(
            "http://127.0.0.1:8000/search",
            new { query = request.Query }
        );
        if (!fastApiResponse.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to process AI search: {fastApiResponse.StatusCode}");
        }

        // Deserialize response content as int array directly
        var ids = await fastApiResponse.Content.ReadFromJsonAsync<int[]>();
        
        if (ids == null || ids.Length == 0)
        {
            return new PageResult<ProjectCoreCardDto>
            {
                Items = new List<ProjectCoreCardDto>(),
                PageNumber = request.Page,
                PageSize = request.PageSize,
                TotalItems = 0
            };
        }

        // Fetch properties from database matching these ids
        var query = _context.ProjectCores
            .Include(p => p.Developer)
            .Include(p => p.Area)
            .Include(p => p.ProjectMedia)
            .Where(p => ids.Contains(p.ProjectId))
            .AsQueryable();

        // Get total count before pagination
        var totalItems = await query.CountAsync();

        // Apply pagination
        query = query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize);

        var items = await query
            .ProjectTo<ProjectCoreCardDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new PageResult<ProjectCoreCardDto>
        {
            Items = items,
            PageNumber = request.Page,
            PageSize = request.PageSize,
            TotalItems = totalItems
        };
    }

}