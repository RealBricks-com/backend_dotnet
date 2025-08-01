using Microsoft.AspNetCore.Mvc;
using realbricks_user_dotnet_backend.Dtos.ProjectLegalDocumentDtos;
using realbricks_user_dotnet_backend.Services;

namespace realbricks_user_dotnet_backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProjectLegalDocumentController
{
    private readonly ProjectLegalDocumentService _projectLegalDocumentService;

    public ProjectLegalDocumentController(ProjectLegalDocumentService projectLegalDocumentService)
    {
        _projectLegalDocumentService = projectLegalDocumentService;
    }
    
    // action methods

    [HttpGet]
    public async Task<List<ProjectLegalDocumentReadDto>> GetAllProjectLegalDocuments()
    {
        return await _projectLegalDocumentService.GetProjectLegalDocuments();
    }


    [HttpGet("{projectId:int}")]
    public async Task<List<ProjectLegalDocumentReadDto>> GetProjectLegalDocumentByProjectId(int projectId)
    {
        return await _projectLegalDocumentService.GetProjectLegalDocumentByProjectId(projectId);
    }
    
}