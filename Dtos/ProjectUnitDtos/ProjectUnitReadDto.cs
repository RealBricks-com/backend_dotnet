namespace realbricks_user_dotnet_backend.Dtos.ProjectUnitDtos;

public class ProjectUnitReadDto
{
    public int UnitId { get; set; }
    public int ProjectId { get; set; }
    public string UnitType { get; set; }
    public int CarpetAreaSqft { get; set; }
    public decimal PriceStarting { get; set; }
    public decimal PriceEnding { get; set; }
    public int UnitsAvailable { get; set; }
    public int Floors { get; set; }
    
}