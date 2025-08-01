namespace realbricks_user_dotnet_backend.Dtos.LeadDtos;

public class LeadCreateDto
{
    public int ProjectId { get; set;}
    public int DeveloperId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public decimal BudgetMin { get; set; }
    public decimal BudgetMax { get; set; }
    
}