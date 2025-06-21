using Common.Enums.Game;
using Domain.Entities.System;

namespace Application.DTOs.Game;

public record GameDto(
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