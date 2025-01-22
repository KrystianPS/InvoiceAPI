using InvoiceAPI.Extensions;
using Serilog;



var builder = WebApplication.CreateBuilder(args);

// Konfiguracja logowania przy u¿yciu Serilog
builder.Logging.ClearProviders();
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()  // Logowanie do konsoli
    .WriteTo.File("logs/app.log",  // Logowanie do pliku
        rollingInterval: RollingInterval.Day, // Nowy plik codziennie
        retainedFileCountLimit: 8, // Maksymalna liczba plików
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}") // Szablon logów
    .CreateLogger();
builder.Host.UseSerilog();


builder.Services.AddLogging();

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();


//using var scope = app.Services.CreateScope();
//var services = scope.ServiceProvider;

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

