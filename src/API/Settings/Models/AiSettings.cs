namespace CFour.Settings.Models;

/// <summary>
/// Represents the configuration settings required for AI services.
/// </summary>
/// <remarks>
/// This class is primarily used to encapsulate the necessary configuration data for AI functionalities, which
/// include the API key, endpoint URL, timeout duration, and maximum retry attempts.
/// </remarks>
public sealed class AiSettings
{
    public string Key { get; init; } = null!;
    public string EndPoint { get; init; } = null!;
    public int TimeOutByMilliSeconds { get; init; }
    public int MaxRetries { get; init; }
}