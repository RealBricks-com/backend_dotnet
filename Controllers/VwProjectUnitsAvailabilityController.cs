using Microsoft.AspNetCore.Mvc;
using realbricks_user_dotnet_backend.Models;
using realbricks_user_dotnet_backend.Services;

namespace realbricks_user_dotnet_backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class VwProjectUnitsAvailabilityController
{
        private readonly VwUnitAvailabilityService _service;

        public VwProjectUnitsAvailabilityController(VwUnitAvailabilityService service)
        {
                _service = service;
        }
        
        // methods --
        [HttpGet("{project_id:int}")]
        public async Task<VwUnitAvailability> GetUnitAvailability(int ProjectId)
        {
                return await _service.GetProjectAvailability(ProjectId);
        }
}