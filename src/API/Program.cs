using Carter;
using CFour.Database.Helpers;
using CFour.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.ConfigureValidation();
builder.Services.AddCarter();
builder.Services.AddOpenApi();
builder.Services.ConfigureAi(builder.Configuration);
builder.Services.ConfigureServices();
builder.Services.ConfigureMapper();

var app = builder.Build();

await app.SeedAsync();

app.EnableSwaggerAndSwaggerUi();

if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();
app.MapCarter();

app.Run();