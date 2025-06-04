namespace CFour.Database.Settings;

/// <summary>
/// Represents the configuration settings required to connect to a MongoDB instance.
/// </summary>
public sealed class MongoDbSettings
{
    public string ConnectionString { get; init; } = null!;
    public string DatabaseName { get; init; } = null!;
}