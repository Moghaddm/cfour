using Common.Enums.Game;

namespace Application.DTOs.Game;

public record CreateGameDto(
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
    CreateGameRequirementDto MinimumRequirement,
    CreateGameRequirementDto RecommendedRequirement,
    string CreatedBy
);