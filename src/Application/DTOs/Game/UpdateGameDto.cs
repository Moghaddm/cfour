using Common.Enums.Game;
using Domain.Entities.Game;

namespace Application.DTOs.Game;

public record UpdateGameDto(
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
    GameSpecification MinimumRequirement,
    GameSpecification RecommendedRequirement,
    string ModifierUserId
);