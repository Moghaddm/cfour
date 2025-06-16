using CFour.Entities.Game;
using CFour.Entities.System;
using CFour.Entities.User;
using CFour.Enums.Game;
using CFour.Enums.System;

namespace CFour.Database.Helpers;

internal static class DataSeeder
{
    /// <summary>
    /// Seeds initial data into the application database.
    /// </summary>
    /// <param name="app">The WebApplication instance used to access application services.</param>
    /// <returns>A task representing the asynchronous operation of seeding data.</returns>
    internal static async Task SeedAsync(this WebApplication app)
    {
        var scope = app.Services.GetRequiredService<IServiceProvider>().CreateAsyncScope();
        await SeedUsersAsync(scope);
        await SeedGamesAsync(scope);
    }

    private static async Task SeedUsersAsync(AsyncServiceScope scope)
    {
        var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();

        var user = new User(
            Guid.CreateVersion7().ToString(),
            Guid.CreateVersion7().ToString(),
            "John",
            "Doe",
            "john.doe@example.com",
            "1234567890",
            1,
            new List<SystemSpecification>
            {
                new(
                    Guid.CreateVersion7(),
                    [new Processor("Intel Core i3-2100", 2, 4, 3.1, 2.5)],
                    new Memory(4_000, 4_000),
                    new Storage(500_000_000, StorageType.Hdd),
                    [new Gpu("Intel HD Graphics 2000", 1, 1, 3.0, 3.0)],
                    new OperationSystem(OsType.Windows, "Windows 10", OsArchitecture.X64),
                    new Display(720, 1280, 24),
                    soundCard: null,
                    isLaptop: true
                )
            }
        );

        if (!userRepository.GetQueryable().Any()) await userRepository.AddAsync(user, CancellationToken.None);
    }

    private static async Task SeedGamesAsync(AsyncServiceScope scope)
    {
        var gameRepository = scope.ServiceProvider.GetRequiredService<IGameRepository>();

        var game = new Game(
            "Red Dead Redemption 2",
            "A story of outlaw Arthur Morgan and the Van der Linde gang, set in the dying days of the American frontier.",
            [],
            [],
            GameGenre.Action,
            "Rockstar Studios",
            "Rockstar Games",
            new DateTime(2018, 10, 26),
            "https://www.rockstargames.com/reddeadredemption2/",
            4.9,
            new List<GamePlatform>
            {
                GamePlatform.Pc,
                GamePlatform.Ps4,
                GamePlatform.XboxOne
            },
            new List<string> { "Western", "Open-World", "Story-Driven" },
            new SystemSpecification(
                Guid.CreateVersion7(),
                [
                    new Processor("Intel Core i5-2500K", 4, 4, 3.3, 2.5),
                    new Processor("AMD Phenom 9850 Quad-Core Processor", 4, 8, 3.6, 3.6)
                ],
                new Memory(8_000, 8_000),
                new Storage(150_000_000, StorageType.Hdd),
                [new Gpu(" AMD HD 4870", 1, 1, 4.0, 4.0), new Gpu("NVIDIA 9800 ", 1, 1, 4.0, 4.0)],
                new OperationSystem(OsType.Windows, "Windows 7", OsArchitecture.X64),
                new Display(1080, 1920, 32),
                "100% DirectX 10 compatible",
                isLaptop: false
            ),
            new SystemSpecification(
                Guid.CreateVersion7(),
                [
                    new Processor("AMD Ryzen 5 1500X", 4, 8, 3.5, 3.7),
                    new Processor("Intel Core i7-6700HQ", 4, 8, 2.6, 3.1)
                ],
                new Memory(12_000, 8_000),
                new Storage(150_000_000, StorageType.Hdd),
                [new Gpu("NVIDIA GeForce GTX 1060", 2, 2, 5.0, 5.0), new Gpu("AMD HD 7870", 2, 2, 5.0, 5.0)],
                new OperationSystem(OsType.Windows, "Windows 10", OsArchitecture.X64),
                new Display(1440, 2560, 32),
                "100% DirectX 10 compatible",
                isLaptop: false
            )
        );

        if (!gameRepository.GetQueryable().Any()) await gameRepository.AddAsync(game, CancellationToken.None);
    }
}