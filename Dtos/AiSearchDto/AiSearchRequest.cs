namespace realbricks_user_dotnet_backend.Dtos.AiSearchDto;

public class AiSearchRequest
{
    public string Query { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 12;
}