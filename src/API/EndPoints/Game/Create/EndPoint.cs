using Application.Services.Interfaces;
using Carter;
using CFour.EndPoints.Game.Common.Mappers;
using CFour.Extensions;
using Common.Constants;

namespace CFour.EndPoints.Game.Create;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureConstants.Game.Prefix).WithTags(FeatureConstants.Game.EndpointTagName)
            .MapPost(string.Empty,
                async (CreateGameRequest request, IGameService gameService, CancellationToken cancellationToken) =>
                {
                    var userId = "";
                    var dto = request.MapToDto(userId);
                    await gameService.CreateAsync(dto, cancellationToken);
                }
            ).Validator<CreateGameRequestValidator>();
    }
}