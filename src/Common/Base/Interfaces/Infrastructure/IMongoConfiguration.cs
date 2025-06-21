namespace Common.Base.Interfaces.Infrastructure;

/// <summary>
/// Defines the MongoDB configuration interface, responsible for setting up
/// necessary mappings and configurations for database entities.
/// </summary>
public interface IMongoConfiguration
{
    /// <summary>
    /// Configures the mapping and serialization settings for MongoDB entities.
    /// This method is responsible for registering class maps for entities
    /// to ensure proper handling and serialization within MongoDB.
    /// </summary>
    void Configure();
}