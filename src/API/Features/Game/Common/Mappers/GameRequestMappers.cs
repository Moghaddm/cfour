using CFour.DTOs.Game;
using CFour.Features.Game.Create;
using CFour.Features.Game.Get;
using CFour.Features.Game.Update;

namespace CFour.Features.Game.Common.Mappers;

public static class GameRequestMappers
{
    public static CreateGameDto MapToDto(this CreateGameRequest request, string creatorUserId)
    {
        return new CreateGameDto(
            request.Title,
            request.Description,
            request.PhotoIds,
            request.TrailerIds,
            request.Genre,
            request.Developer,
            request.Publisher,
            request.ReleaseDate,
            request.OfficialWebsite,
            request.Rating,
            request.AvailablePlatforms,
            request.Tags,
            request.MinimumRequirement.MapToDto(),
            request.RecommendedRequirement.MapToDto(),
            creatorUserId
        );
    }

    private static CreateGameRequirementDto MapToDto(this CreateGameRequirementRequest request)
    {
        return new CreateGameRequirementDto(
            request.Processors,
            request.Memory,
            request.Storage,
            request.Gpus,
            request.OperationSystem,
            request.Display,
            request.SoundCard,
            request.IsLaptop
        );
    }

    public static UpdateGameDto MapToDto(this UpdateGameRequest request, string modifierUserId)
    {
        return new UpdateGameDto(
            request.Title,
            request.Description,
            request.PhotoIds,
            request.TrailerIds,
            request.Genre,
            request.Developer,
            request.Publisher,
            request.ReleaseDate,
            request.OfficialWebsite,
            request.Rating,
            request.AvailablePlatforms,
            request.Tags,
            request.MinimumRequirement,
            request.RecommendedRequirement,
            modifierUserId
        );
    }

    public static GetGameResponse MapToResponse(this GameDto gameDto)
    {
        return new GetGameResponse(
            gameDto.Title,
            gameDto.Description,
            gameDto.PhotoIds,
            gameDto.TrailerIds,
            gameDto.Genre,
            gameDto.Developer,
            gameDto.Publisher,
            gameDto.ReleaseDate,
            gameDto.OfficialWebsite,
            gameDto.Rating,
            gameDto.AvailablePlatforms,
            gameDto.Tags,
            gameDto.MinimumRequirement,
            gameDto.RecommendedRequirement
        );
    }
}