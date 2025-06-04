using Swashbuckle.AspNetCore.SwaggerUI;

namespace CFour.Extensions;

internal static class ApplicationExtensions
{
    /// <summary>
    /// Configures and enables Swagger and Swagger UI middleware for the application.
    /// </summary>
    /// <param name="app">The <see cref="IApplicationBuilder"/> instance used for configuring the application's middleware pipeline.</param>
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