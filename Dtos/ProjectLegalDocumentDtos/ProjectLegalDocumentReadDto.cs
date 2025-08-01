namespace realbricks_user_dotnet_backend.Dtos.ProjectLegalDocumentDtos;

public class ProjectLegalDocumentReadDto
{
    public int DocumentId { get; set; }
    public int ProjectId { get; set; }
    public string DocumentType { get; set; }
    public string DocumentUrl { get; set; }
    public string VerificationStatus { get; set; }
    public string Remarks { get; set; }
}