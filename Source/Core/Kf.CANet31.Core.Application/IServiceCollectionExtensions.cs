using Kf.Essentials.CleanArchitecture.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace Kf.CANet31.Core.Application
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection serviceCollection
        )
            => serviceCollection
                .AddAndConfigureMediatR()
                .AddAndConfigureAutomapper();
    }
}
