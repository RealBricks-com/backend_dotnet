using AutoMapper;
using realbricks_user_dotnet_backend.Dtos.AmenityDtos;
using realbricks_user_dotnet_backend.Dtos.AreaDtos;
using realbricks_user_dotnet_backend.Dtos.CityDto;
using realbricks_user_dotnet_backend.Dtos.DeveloperCoreDtos;
using realbricks_user_dotnet_backend.Dtos.LeadDtos;
using realbricks_user_dotnet_backend.Dtos.ProjectCoreDtos;
using realbricks_user_dotnet_backend.Dtos.ProjectLegalDocumentDtos;
using realbricks_user_dotnet_backend.Dtos.ProjectMediumDtos;
using realbricks_user_dotnet_backend.Dtos.ProjectNearbyLocationDtos;
using realbricks_user_dotnet_backend.Models;

namespace realbricks_user_dotnet_backend.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<City, CityReadDto>();
        CreateMap<Area, AreaReadDto>();
        CreateMap<DeveloperCore, DeveloperCoreReadDto>();
        CreateMap<ProjectCore, ProjectCoreDto>();
        CreateMap<ProjectMedium, ProjectMediumDto>();
        CreateMap<ProjectMedium, ProjectMediumDto>();
        // DTO => ENTITY
        CreateMap<LeadCreateDto, Lead>();
        CreateMap<ProjectLegalDocument, ProjectLegalDocumentReadDto>();
        CreateMap<ProjectNearbyLocation, ProjectNearbyLocationReadDto>();
        CreateMap<Amenity, AmenityReadDto>();
        CreateMap<Area, AreaReadDto>();
    }
}