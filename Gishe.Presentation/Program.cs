using Gishe.Presentation.Infrastructure.DependencyInjection;
using Gishe.Presention.Application.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApplication();

builder.Services.AddInfrastructure();

var app = builder.Build();

app.MapControllers();

app.Run();