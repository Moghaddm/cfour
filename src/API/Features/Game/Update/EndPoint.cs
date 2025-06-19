using Carter;
using CFour.Constants;
using CFour.Features.Game.Common.Mappers;
using CFour.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CFour.Features.Game.Update;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(FeatureConstants.Game.Prefix).WithTags(FeatureConstants.Game.EndpointTagName);

        group.MapPut(string.Empty,
            async ([FromRoute] string id, UpdateGameRequest request, IGameService gameService,
                CancellationToken cancellationToken) =>
            {
                var userId = "";
                var dto = request.MapToDto(userId);
                await gameService.UpdateAsync(id, dto, cancellationToken);
            });
    }
}