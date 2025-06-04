using CFour.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureDatabase(builder.Configuration);

var app = builder.Build();

app.UseCustomSwagger();
if (app.Environment.IsDevelopment()) app.MapOpenApi();
app.UseHttpsRedirection();

app.Run();