using System.Reflection;
using Common.Base.Interfaces;
using Common.Base.Interfaces.Infrastructure;
using Domain.Entities.Game;
using Domain.Entities.Match;
using Domain.Entities.User;
using Infrastructure.Database.Repositories;
using Infrastructure.Database.Settings;
using MongoDB.Driver;

namespace CFour.Extensions;

internal static class DatabaseExtensions
{
    internal static void ConfigureDatabase(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.SetupMongoDbClient(configuration);
        RegisterMapping();
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
    }

    private static void RegisterMapping()
    {
        var assembly = Assembly.GetAssembly(typeof(DatabaseExtensions))!;

        var configures = assembly.GetTypes()
            .Where(t => typeof(IMongoConfiguration).IsAssignableFrom(t) && t is { IsAbstract: false, IsClass: true })
            .ToList();

        foreach (var configType in configures)
            if (Activator.CreateInstance(configType) is IMongoConfiguration configInstance)
                configInstance.Configure();
    }

    private static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IGameRepository, GameRepository>();
        services.AddTransient<IMatchRepository, MatchRepository>();
    }
}