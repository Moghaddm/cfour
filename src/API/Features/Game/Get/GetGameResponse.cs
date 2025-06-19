using CFour.Entities.System;
using CFour.Enums.Game;

namespace CFour.Features.Game.Get;

public record GetGameResponse(
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
    SystemSpecification MinimumRequirement,
    SystemSpecification RecommendedRequirement
);