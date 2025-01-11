using InvoiceAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;



app.UseHttpsRedirection();

app.MapControllers();

app.Run();
