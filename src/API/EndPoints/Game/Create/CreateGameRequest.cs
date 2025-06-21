using Common.Enums.Game;
using Domain.Entities.System;

namespace CFour.EndPoints.Game.Create;

public record CreateGameRequest(
    string Title,
    string Description,
    List<string> PhotoIds,
    List<string> TrailerIds,
    GameGenre Genre,
    string Developer,
    string Publisher,
    DateTime ReleaseDate,
    string OfficialWebsite,
    double Rating,
    IList<GamePlatform> AvailablePlatforms,
    IList<string> Tags,
    CreateGameRequirementRequest MinimumRequirement,
    CreateGameRequirementRequest RecommendedRequirement
);

public record struct CreateGameRequirementRequest(
    IList<Processor> Processors,
    Memory Memory,
    Storage Storage,
    IList<Gpu> Gpus,
    OperationSystem OperationSystem,
    Display Display,
    string? SoundCard,
    bool IsLaptop
);