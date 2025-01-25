using InvoiceAPI.Extensions;
using InvoiceAPI.Middleware;
using Serilog;



var builder = WebApplication.CreateBuilder(args);


builder.Logging.ClearProviders();
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/app.log",
        rollingInterval: RollingInterval.Day,
        retainedFileCountLimit: 8,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}") // Szablon logów
    .CreateLogger();
builder.Host.UseSerilog();


builder.Services.AddLogging();

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSwaggerGen();


var app = builder.Build();


app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Invoice API");
    c.RoutePrefix = "";
});

app.MapControllers();

app.Run();

