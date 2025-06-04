using CFour.Database.Settings;
using MongoDB.Driver;

namespace CFour.Extensions;

public static class DatabaseExtensions
{
    /// <summary>
    /// Configures the database services for the application by setting up MongoDB client and database instances.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the database services to.</param>
    /// <param name="configuration">The application's configuration manager to retrieve database connection settings.</param>
    public static void ConfigureDatabase(this IServiceCollection services, IConfigurationManager configuration)
    {
        var mongoDbSettings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>()!;

        services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoDbSettings.ConnectionString));

        services.AddScoped(serviceProvider =>
        {
            var client = serviceProvider.GetRequiredService<IMongoClient>();
            return client.GetDatabase(mongoDbSettings.DatabaseName);
        });
    }
}