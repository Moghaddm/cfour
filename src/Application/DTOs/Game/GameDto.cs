using Common.Enums.Game;
using Domain.Entities.Game;

namespace Application.DTOs.Game;

public record GameDto(
    string Title,
    string Description,
    IList<string> PhotoIds,
    IList<string> TrailerIds,
    GameGenre Genre,
    string Developer,
    string Publisher,
    DateTime ReleaseDate,
    string OfficialWebsite,
    IList<string> Tags,
    GameSpecification MinimumRequirement,
    GameSpecification RecommendedRequirement
);