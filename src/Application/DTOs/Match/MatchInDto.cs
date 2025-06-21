namespace Application.DTOs.Match;

public record MatchInDto(
    string GameId,
    string UserId,
    string SystemSpecificationUnique
);