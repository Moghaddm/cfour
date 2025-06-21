using Application.Services.Interfaces;
using Carter;
using CFour.EndPoints.Game.Common.Mappers;
using Common.Constants;
using Microsoft.AspNetCore.Mvc;

namespace CFour.EndPoints.Game.Get;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(FeatureConstants.Game.Prefix).WithTags(FeatureConstants.Game.EndpointTagName);

        group.MapGet("{id}",
            async ([FromRoute] string id, IGameService gameService, CancellationToken cancellationToken) =>
            {
                var game = await gameService.GetAsync(id, cancellationToken);
                return game.MapToResponse();
            });
    }
}