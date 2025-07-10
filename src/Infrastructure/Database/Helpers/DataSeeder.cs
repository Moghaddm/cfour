using Common.Enums.Game;
using Common.Enums.System;
using Domain.Entities.Game;
using Domain.Entities.Game.Specification;
using Domain.Entities.User;
using Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver.Linq;
using OperatingSystem = Domain.Entities.Game.Specification.OperatingSystem;

namespace Infrastructure.Database.Helpers;

public static class DataSeeder
{
    /// <summary>
    /// Seeds initial data into the application database.
    /// </summary>
    /// <param name="app">The WebApplication instance used to access application services.</param>
    /// <returns>A task representing the asynchronous operation of seeding data.</returns>
    public static async Task SeedAsync(this WebApplication app)
    {
        var scope = app.Services.GetRequiredService<IServiceProvider>().CreateAsyncScope();
        var userId = await SeedUsersAsync(scope);
        await SeedGamesAsync(scope, userId);
    }

    private static async Task<string> SeedUsersAsync(AsyncServiceScope scope)
    {
        var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();

        var user = await userRepository.GetQueryable().FirstOrDefaultAsync();

        if (user is null) return user!.Id;

        user = new User(
            Guid.CreateVersion7().ToString(),
            Guid.CreateVersion7().ToString(),
            "John",
            "Doe",
            "john.doe@example.com",
            "1234567890",
            ""
        );
        await userRepository.AddAsync(user, CancellationToken.None);

        return user.Id;
    }

    private static async Task SeedGamesAsync(AsyncServiceScope scope, string userId)
    {
        var gameRepository = scope.ServiceProvider.GetRequiredService<IGameRepository>();

        var game = new Game(
            "Red Dead Redemption 2",
            "A story of outlaw Arthur Morgan and the Van der Linde gang, set in the dying days of the American frontier.",
            string.Empty,
            [],
            [],
            GameGenre.Action,
            "Rockstar Studios",
            "Rockstar Games",
            new DateTime(2018, 10, 26),
            "https://www.rockstargames.com/reddeadredemption2/",
            new List<string> { "Western", "Open-World", "Story-Driven" },
            new GameSpecification(
                Guid.CreateVersion7(),
                [
                    new Processor("Intel Core i5-2500K", 4, 4, 3.3, 2.5),
                    new Processor("AMD Phenom 9850 Quad-Core Processor", 4, 8, 3.6, 3.6)
                ],
                new Memory(8_000, 8_000),
                new Storage(150_000_000, StorageType.Hdd),
                [new Gpu(" AMD HD 4870", 1, 1, 4.0, 4.0), new Gpu("NVIDIA 9800 ", 1, 1, 4.0, 4.0)],
                new OperatingSystem(OsType.Windows, "Windows 7", OsArchitecture.X64),
                new Display(1080, 1920, 32),
                "100% DirectX 10 compatible"
            ),
            new GameSpecification(
                Guid.CreateVersion7(),
                [
                    new Processor("AMD Ryzen 5 1500X", 4, 8, 3.5, 3.7),
                    new Processor("Intel Core i7-6700HQ", 4, 8, 2.6, 3.1)
                ],
                new Memory(12_000, 8_000),
                new Storage(150_000_000, StorageType.Hdd),
                [new Gpu("NVIDIA GeForce GTX 1060", 2, 2, 5.0, 5.0), new Gpu("AMD HD 7870", 2, 2, 5.0, 5.0)],
                new OperatingSystem(OsType.Windows, "Windows 10", OsArchitecture.X64),
                new Display(1440, 2560, 32),
                "100% DirectX 10 compatible"
            ),
            userId
        );

        if (!gameRepository.GetQueryable().Any()) await gameRepository.AddAsync(game, CancellationToken.None);
    }
}