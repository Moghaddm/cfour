using Carter;
using CFour.Constants;
using CFour.Extensions;
using CFour.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CFour.Features.Match.Create;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureConstants.Match.Prefix).WithTags(FeatureConstants.Match.EndpointTagName)
            .MapPost(string.Empty,
                async (
                    [FromBody] CreateMatchRequest request,
                    IMatchService matchService,
                    CancellationToken cancellationToken
                ) =>
                {
                    var inDto = request.MapToDto();
                    await matchService.MatchAsync(inDto, cancellationToken);
                })
            .Validator<CreateMatchRequestValidator>();
    }
}