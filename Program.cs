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
    var seeder = services.GetRequiredService<DatabaseSeeder>();
    await seeder.Seed();
}
catch (Exception ex)
{
    // Handle exceptions, e.g., log them
    Console.WriteLine($"An error occurred during seeding: {ex.Message}");
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
