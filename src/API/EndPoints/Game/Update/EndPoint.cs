using Application.Services.Interfaces;
using Carter;
using CFour.EndPoints.Game.Common.Mappers;
using Common.Constants;
using Microsoft.AspNetCore.Mvc;

namespace CFour.EndPoints.Game.Update;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureConstants.Game.Prefix).WithTags(FeatureConstants.Game.EndpointTagName)
            .MapPut(string.Empty,
                async ([FromRoute] string id, UpdateGameRequest request, IGameService gameService,
                    CancellationToken cancellationToken) =>
                {
                    var userId = "";
                    var dto = request.MapToDto(userId);
                    await gameService.UpdateAsync(id, dto, cancellationToken);
                });
    }
}