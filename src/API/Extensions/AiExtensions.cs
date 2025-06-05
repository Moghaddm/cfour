using System.ClientModel;
using System.ClientModel.Primitives;
using CFour.Ai.Models;
using OpenAI;

namespace CFour.Extensions;

internal static class AiExtensions
{
    /// <summary>
    /// Configures AI-related services, including the setup of the OpenAI client, by using application configuration.
    /// </summary>
    /// <param name="services">The IServiceCollection instance to which AI-related services will be added.</param>
    /// <param name="configuration">The IConfiguration instance used to retrieve AI settings from the application's configuration.</param>
    internal static void ConfigureAi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<OpenAIClient>(_ =>
        {
            var aiSettings = configuration.GetSection(nameof(AiSettings)).Get<AiSettings>()!;
            return new OpenAIClient(
                new ApiKeyCredential(aiSettings.Key), new OpenAIClientOptions
                {
                    Endpoint = new Uri(aiSettings.EndPoint),
                    NetworkTimeout = TimeSpan.FromMilliseconds(aiSettings.TimeOutByMilliSeconds),
                    RetryPolicy = new ClientRetryPolicy(aiSettings.MaxRetries)
                }
            );
        });
    }
}