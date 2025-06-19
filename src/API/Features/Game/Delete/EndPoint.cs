using Carter;
using CFour.Constants;
using CFour.Services.Interfaces;

namespace CFour.Features.Game.Delete;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(FeatureConstants.Game.Prefix).WithTags(FeatureConstants.Game.EndpointTagName);

        group.MapDelete(string.Empty,
            async (string id, IGameService gameService, CancellationToken cancellationToken) =>
            {
                var userId = "";
                await gameService.DeleteAsync(id, userId, cancellationToken);
            }
        );
    }
}