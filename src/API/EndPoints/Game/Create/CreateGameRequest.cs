using Common.Enums.Game;
using Domain.Entities.Game.Specification;
using OperatingSystem = Domain.Entities.Game.Specification.OperatingSystem;

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
    IList<string> Tags,
    CreateGameRequirementRequest MinimumRequirement,
    CreateGameRequirementRequest RecommendedRequirement
);

public record struct CreateGameRequirementRequest(
    IList<Processor> Processors,
    Memory Memory,
    Storage Storage,
    IList<Gpu> Gpus,
    OperatingSystem OperatingSystem,
    Display Display,
    string? SoundCard,
    bool IsLaptop
);