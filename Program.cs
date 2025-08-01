using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using realbricks_user_dotnet_backend.Data;
using realbricks_user_dotnet_backend.Models;
using realbricks_user_dotnet_backend.Profiles;
using realbricks_user_dotnet_backend.Services;

var builder = WebApplication.CreateBuilder(args);

// dependency injection
builder.Services.AddScoped<AmenityService>();
builder.Services.AddScoped<AreaService>();
builder.Services.AddScoped<CityService>();
builder.Services.AddScoped<CountryService>();
builder.Services.AddScoped<DeveloperService>();
builder.Services.AddScoped<ProjectCoreService>();
builder.Services.AddScoped<ProjectMediumService>();
builder.Services.AddScoped<TestViewService>();
builder.Services.AddScoped<VwUnitAvailabilityService>();
builder.Services.AddScoped<LeadService>();
builder.Services.AddScoped<ProjectLegalDocumentService>();
builder.Services.AddScoped<ProjectNearbyLocationService>();
builder.Services.AddScoped<ProjectSpecificationService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddResponseCaching(); // Enable caching services

builder.Services.AddAutoMapper(typeof(MappingProfile));  


builder.Services.AddDbContext<RealBricksContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddControllers(options =>
{
    options.CacheProfiles.Add("DefaultCache", new CacheProfile
    {
        Duration = 60,
        Location = ResponseCacheLocation.Any
    });
});


var app = builder.Build();

// ---



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseResponseCaching();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

