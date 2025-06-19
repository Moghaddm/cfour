using Carter;
using CFour.Constants;
using CFour.Extensions;
using CFour.Features.Game.Common.Mappers;
using CFour.Services.Interfaces;

namespace CFour.Features.Game.Create;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(FeatureConstants.Game.Prefix).WithTags(FeatureConstants.Game.EndpointTagName);

        group.MapPost(string.Empty,
            async (CreateGameRequest request, IGameService gameService, CancellationToken cancellationToken) =>
            {
                var userId = "";
                var dto = request.MapToDto(userId);
                await gameService.CreateAsync(dto, cancellationToken);
            }
        ).Validator<CreateGameRequestValidator>();

        group.MapDelete(string.Empty,
            async (string id, IGameService gameService, CancellationToken cancellationToken) =>
            {
                var userId = "";
                await gameService.DeleteAsync(id, userId, cancellationToken);
            }
        );
    }
}