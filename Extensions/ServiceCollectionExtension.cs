using InvoiceAPI.MappingProfiles;
using InvoiceAPI.Persistance;
using InvoiceAPI.Seeders;
using InvoiceAPI.Seeders.EntitySeeders;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InvoiceAPIDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("LocalDBDevelopmentConnectionString")));


            services.AddScoped<DatabaseSeeder>();
            services.AddScoped<VatRateSeeder>();
            services.AddScoped<ContractorSeeder>();
            services.AddScoped<CompanySeeder>();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<CompanyMappingProfile>();
                cfg.AddProfile<ContractorMappingProfile>();
            });




        }

    }
}
