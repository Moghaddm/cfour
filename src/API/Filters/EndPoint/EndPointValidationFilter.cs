using System.Net;
using FluentValidation;

namespace CFour.Filters.EndPoint;

internal sealed class EndPointValidationFilter<T>(IValidator<T> validator) : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var inputData = context.GetArgument<T>(0);
        if (inputData is null) return await next.Invoke(context);

        var validationResult = await validator.ValidateAsync(inputData, CancellationToken.None);
        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary(),
                statusCode: (int)HttpStatusCode.UnprocessableEntity);
        }

        return await next.Invoke(context);
    }
}