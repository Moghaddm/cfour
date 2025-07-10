using Application.Services.Interfaces;
using Carter;
using CFour.Extensions;
using Common.Constants;
using Microsoft.AspNetCore.Mvc;

namespace CFour.EndPoints.Compare.Create;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureConstants.Compare.Prefix).WithTags(FeatureConstants.Compare.EndpointTagName)
            .MapPost(string.Empty,
                async (
                    [FromBody] CreateCompareRequest request,
                    ICompareService compareService,
                    CancellationToken cancellationToken
                ) =>
                {
                    var inDto = request.MapToDto();
                    await compareService.CompareAsync(inDto, cancellationToken);
                })
            .Validator<CreateCompareRequest>();
    }
}