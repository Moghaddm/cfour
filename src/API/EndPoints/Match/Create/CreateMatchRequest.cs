namespace CFour.Features.Match.Create;

public record CreateMatchRequest(
    string GameId,
    string ChosenSystemSpecificationUnique
);