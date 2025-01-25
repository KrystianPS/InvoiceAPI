using InvoiceAPI.Middleware;
using InvoiceAPI.Persistance;
using InvoiceAPI.Seeders;
using InvoiceAPI.Seeders.EntitySeeders;
using InvoiceAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InvoiceAPIDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("Dev")));


            services.AddScoped<DatabaseSeeder>();
            services.AddScoped<VatRateSeeder>();
            services.AddScoped<ContractorSeeder>();
            services.AddScoped<CompanySeeder>();


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IContractorService, ContractorService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IInvoiceService, InvoiceService>();

            services.AddScoped<ErrorHandlingMiddleware>();

            services.AddSwaggerGen();
        }


    }
}
