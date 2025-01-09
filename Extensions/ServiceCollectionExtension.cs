using InvoiceAPI.Persistance;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InvoiceAPIDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("LocalDBDevelopmentConnectionString")));



        }

    }
}
