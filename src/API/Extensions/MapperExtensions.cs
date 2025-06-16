namespace CFour.Extensions;

internal static class MapperExtensions
{
    internal static void ConfigureMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IAssemblyMarker));
    }
}