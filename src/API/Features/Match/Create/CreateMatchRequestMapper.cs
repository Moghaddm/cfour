using CFour.DTOs.Match;

namespace CFour.Features.Match.Create;

internal static class CreateMatchRequestMapper
{
    internal static MatchInDto MapToDto(this CreateMatchRequest request)
    {
        return new MatchInDto(
            request.GameId,
            "", // TODO: AFTER AUTH FINISH THIS
            request.ChosenSystemSpecificationUnique
        );
    }
}