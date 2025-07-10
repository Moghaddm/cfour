using Application.DTOs.Compare;

namespace CFour.EndPoints.Compare.Create;

internal static class CreateCompareRequestMapper
{
    internal static CompareInDto MapToDto(this CreateCompareRequest request)
    {
        return new CompareInDto(
            request.GameId,
            "01975072-7f92-72e6-998a-7a66bcb46a90", // TODO: AFTER AUTH FINISH THIS
            request.ChosenSystemSpecificationUnique
        );
    }
}