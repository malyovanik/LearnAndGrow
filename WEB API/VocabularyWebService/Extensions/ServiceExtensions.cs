using Contracts.WEB.Interfaces;
using Entities.WEB;
using Microsoft.EntityFrameworkCore;
using Repository.WEB.Wrappers;

namespace VocabularyWebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("EmployeeAppCon");
            services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString,
                MySqlServerVersion.LatestSupportedServerVersion));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}