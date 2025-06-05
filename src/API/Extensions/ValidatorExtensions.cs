using CFour.Filters.EndPoint;

namespace CFour.Extensions;

internal static class ValidatorExtensions
{
    /// <summary>
    /// Adds an endpoint validation filter to the route handler for the specified type.
    /// </summary>
    /// <param name="handlerBuilder">The route handler builder to which the validation filter is added.</param>
    /// <typeparam name="T">The type for which validation is performed. Must be a class.</typeparam>
    public static void Validator<T>(this RouteHandlerBuilder handlerBuilder) where T : class
    {
        handlerBuilder.AddEndpointFilter<EndPointValidationFilter<T>>();
    }
}