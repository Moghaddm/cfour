using Swashbuckle.AspNetCore.SwaggerUI;

namespace CFour.Extensions;

internal static class ApplicationExtensions
{
    internal static void UseCustomSwagger(this IApplicationBuilder app)
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