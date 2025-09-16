using webapplicationcp4.Interfaces;
using webapplicationcp4.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Mantém nomes das propriedades
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GeoMaster API",
        Version = "v1",
        Description = "API para cálculos geométricos 2D e 3D com validações de contenção.",
        Contact = new OpenApiContact
        {
            Name = "GeoMaster Team"
        }
    });

    // Inclui comentários XML
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

// Registro de serviços
builder.Services.AddScoped<ICalculadoraService, CalculadoraService>();
builder.Services.AddScoped<IValidacoesService, ValidacoesService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "GeoMaster API v1");
        options.RoutePrefix = string.Empty; // Define Swagger UI como página inicial
        options.DocumentTitle = "GeoMaster API Documentation";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();