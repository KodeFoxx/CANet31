using Kf.CANet31.Core.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kf.CANet31.Infrastructure.Persistence.Ef
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddAndConfigureSqlServerPersistence(
            this IServiceCollection serviceCollection,
            IConfiguration configuration
        )
            => serviceCollection
                .AddAndConfigureSqlServerDbContext<DatabaseContext>(
                    connectionString: configuration.GetConnectionString(nameof(DatabaseContext))
                )
                .AddDbContextScoped<IDatabaseContext, DatabaseContext>();

        private static IServiceCollection AddAndConfigureSqlServerDbContext<TConcreteDbContext>(
            this IServiceCollection serviceCollection,
            string connectionString
        )
            where TConcreteDbContext : DbContext
            => serviceCollection
                .AddDbContext<TConcreteDbContext>(options =>
                    options.UseSqlServer(
                        connectionString: connectionString,
                        sqlServerOptionsAction: sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(typeof(TConcreteDbContext).Assembly.FullName);
                        })
                );

        private static IServiceCollection AddDbContextScoped<TDbContext, TConcreteDbContext>(
            this IServiceCollection serviceCollection
        )
            where TConcreteDbContext : DbContext, TDbContext
            where TDbContext : class
            => serviceCollection.AddScoped<TDbContext>(
                implementationFactory: provider => provider.GetService<TConcreteDbContext>());
    }
}
