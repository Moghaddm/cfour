using Application.Services.Interfaces;
using Carter;
using CFour.Extensions;
using CFour.Features.Match.Create;
using Common.Constants;
using Microsoft.AspNetCore.Mvc;

namespace CFour.EndPoints.Match.Create;

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
            .Validator<CreateMatchRequest>();
    }
}