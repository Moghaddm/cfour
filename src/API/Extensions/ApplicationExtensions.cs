using Swashbuckle.AspNetCore.SwaggerUI;

namespace CFour.Extensions;

/// <summary>
/// IApplicationBuilder extensions for Swagger middlewares setup
/// </summary>
internal static class ApplicationExtensions
{
    /// <summary>
    /// application middleware for swagger
    /// </summary>
    /// <param name="app"></param>
    public static void UseCustomSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.DocumentTitle = Constants.Constants.ApiDocumentationTitle;
            options.DocExpansion(DocExpansion.None);
            options.DisplayRequestDuration();
            options.EnableDeepLinking();
            options.EnableFilter();
            options.ShowExtensions();
            options.DefaultModelRendering(ModelRendering.Model);
            options.ShowCommonExtensions();
            options.EnableValidator();
        });
    }
}