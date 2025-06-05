using CFour.Services.Implementations;
using CFour.Services.Interfaces;

namespace CFour.Extensions;

internal static class ServiceExtensions
{
    /// <summary>
    /// Configures services required by the application.
    /// Registers service implementations for dependency injection.
    /// </summary>
    /// <param name="services">An IServiceCollection instance to which services are added.</param>
    internal static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IMatchService, MatchService>();
    }
}