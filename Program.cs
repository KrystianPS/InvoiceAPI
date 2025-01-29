using InvoiceAPI.Extensions;
using InvoiceAPI.Middleware;
using Microsoft.AspNetCore.Identity;
using Serilog;
using System.Security.Claims;



var builder = WebApplication.CreateBuilder(args);


builder.Logging.ClearProviders();
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Logger(lc => lc
        .Filter.ByIncludingOnly(evt => evt.Properties.ContainsKey("SourceContext") &&
                                       evt.Properties["SourceContext"].ToString().Contains("ErrorHandlingMiddleware"))
        .WriteTo.File("logs/errorhandling.log",
            rollingInterval: RollingInterval.Day,
            retainedFileCountLimit: 5,
            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"))
    .WriteTo.Logger(lc => lc
            .Filter.ByIncludingOnly(evt => evt.Properties.ContainsKey("SourceContext") &&
                                           evt.Properties["SourceContext"].ToString().Contains("RequestTimeMiddleware"))
            .WriteTo.File("logs/requesttime.log",
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 5,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"))
    .CreateLogger();


builder.Host.UseSerilog();


builder.Services.AddLogging();


builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSwaggerGen();


var app = builder.Build();


app.UseHttpsRedirection();

app.MapIdentityApi<IdentityUser>();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestTimeMiddleware>();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Invoice API");
    c.RoutePrefix = "";
});

app.MapControllers();

//test identity
app.MapGet("/test", (ClaimsPrincipal user) => $"Hello {user.Identity!.Name}").RequireAuthorization();

app.Run();

