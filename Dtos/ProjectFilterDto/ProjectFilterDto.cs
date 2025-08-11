namespace realbricks_user_dotnet_backend.Dtos.ProjectFilterDto;

public class ProjectFilterDto
{
    public int? AreaId { get; set; }
    public string? PropertyType { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public string? Status { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}