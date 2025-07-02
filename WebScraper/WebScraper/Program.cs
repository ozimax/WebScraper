using System.Net;
using System.Text.Json.Serialization;
using System.Text.Json;
using WebScraper.Application.Interfaces;
using WebScraper.Application.Services;
using WebScraper.Domain.Interfaces;
using WebScraper.Infastructure.HttpClients;
using WebScraper.Infastructure.Services;
using WebScraper.Infastructure.Interfaces;

System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddScoped<ISearchHttpClient, SearchHttpClient>();

builder.Services.AddScoped<GoogleSearchService>();
builder.Services.AddScoped<BingSearchService>();
builder.Services.AddScoped<ISearchEngineServiceFactory, SearchEngineServiceFactory>();
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<ISearchHistoryLogger, JsonSearchHistoryLogger>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});




// Add services to the container.

//builder.Services.AddControllers();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAll");

app.Run();
