using CFour.Database.Configuration;
using CFour.Database.Repositories;
using CFour.Database.Settings;
using CFour.Entities.Game;
using CFour.Entities.Match;
using CFour.Entities.User;
using MongoDB.Driver;

namespace CFour.Extensions;

internal static class DatabaseExtensions
{
    internal static void ConfigureDatabase(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.SetupMongoDbClient(configuration);
        services.ConfigureRepositories();
    }

    private static void SetupMongoDbClient(this IServiceCollection services, IConfigurationManager configuration)
    {
        var mongoDbSettings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>()!;
        services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoDbSettings.ConnectionString));
        services.AddScoped(serviceProvider =>
        {
            var client = serviceProvider.GetRequiredService<IMongoClient>();
            return client.GetDatabase(mongoDbSettings.DatabaseName);
        });

        GameConfiguration.RegisterMappings();
    }

    private static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IGameRepository, GameRepository>();
        services.AddTransient<IMatchRepository, MatchRepository>();
    }
}