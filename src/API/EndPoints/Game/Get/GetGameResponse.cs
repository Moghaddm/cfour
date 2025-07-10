using Common.Enums.Game;
using Domain.Entities.Game;

namespace CFour.EndPoints.Game.Get;

public record GetGameResponse(
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