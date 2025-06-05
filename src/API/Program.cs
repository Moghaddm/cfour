using CFour.Database.Helpers;
using CFour.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureAi(builder.Configuration);
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.ConfigureServices();

var app = builder.Build();

await app.SeedAsync();

app.EnableSwaggerAndSwaggerUi();
if (app.Environment.IsDevelopment()) app.MapOpenApi();
app.UseHttpsRedirection();

app.Run();