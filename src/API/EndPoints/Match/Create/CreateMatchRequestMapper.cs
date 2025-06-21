using Application.DTOs.Match;

namespace CFour.Features.Match.Create;

internal static class CreateMatchRequestMapper
{
    internal static MatchInDto MapToDto(this CreateMatchRequest request)
    {
        return new MatchInDto(
            request.GameId,
            "01975072-7f92-72e6-998a-7a66bcb46a90", // TODO: AFTER AUTH FINISH THIS
            request.ChosenSystemSpecificationUnique
        );
    }
}