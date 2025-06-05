using Carter;
using CFour.Constants;
using CFour.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CFour.Features.Match.Create;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureConstants.Match.Prefix).WithTags(FeatureConstants.Match.EndpointTagName)
            .MapPost("", async ([FromBody] CreateMatchRequest request) =>
            {
                Console.WriteLine();
                await Task.CompletedTask;
            }).Validator<CreateMatchRequestValidator>();
    }
}