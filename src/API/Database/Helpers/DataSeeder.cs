using CFour.Entities.Game;
using CFour.Entities.System;
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
        var gameRepository = app.Services.GetRequiredService<IGameRepository>();

        var game = new Game(
            "Epic Adventure",
            "An epic journey in a vast and dangerous fantasy world.",
            [],
            [],
            GameGenre.Adventure,
            "Adventure Studios",
            "Fantasy Corp",
            new DateTime(2024, 5, 15),
            "https://epicadventure.example.com",
            4.8,
            new List<GamePlatform>
            {
                GamePlatform.Pc,
                GamePlatform.Ps4,
                GamePlatform.Ps5,
                GamePlatform.XboxOne
            },
            new List<string> { "Fantasy", "Open-World", "Exploration" },
            new SystemSpecification(
                Guid.CreateVersion7(),
                new Processor("Intel Core i5-2500K", 4, 4, 3.3, 2.2),
                new Memory(8_000, 8_000),
                new Storage(150_000_000, StorageType.Hdd),
                new Gpu("NVIDIA GeForce GTX 770", 2),
                new OperationSystem(OsType.Windows, "Windows 10 Enterprise", OsArchitecture.X64),
                new Display(1080, 1920, 32),
                isLaptop: false
            ),
            new SystemSpecification(
                Guid.CreateVersion7(),
                new Processor("AMD Ryzen 5 3600", 6, 12, 3.6, 4.2),
                new Memory(16_000, 12_000),
                new Storage(512_000_000, StorageType.Hdd),
                new Gpu("NVIDIA GeForce GTX 1660 Super", 6),
                new OperationSystem(OsType.Windows, "Windows 11 Pro", OsArchitecture.X64),
                new Display(1440, 2560, 32),
                isLaptop: false
            )
        );

        await gameRepository.AddAsync(game, CancellationToken.None);
    }
}