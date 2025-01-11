using InvoiceAPI.Extensions;
using InvoiceAPI.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();


using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var databaseSeeder = services.GetRequiredService<DatabaseSeeder>();
    await databaseSeeder.Seed();
}
catch (Exception ex)
{
    Console.WriteLine($"B³¹d podczas seedowania danych: {ex.Message}");
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
