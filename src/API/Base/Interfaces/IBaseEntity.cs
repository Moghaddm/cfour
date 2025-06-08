
namespace CFour.Base.Interfaces;

/// <summary>
/// Defines a base entity structure with a generic identifier.
/// </summary>
public interface IBaseEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    string Id { get; init; }

    /// <summary>
    /// Gets or sets the concurrency token used to handle optimistic concurrency control scenarios.
    /// </summary>
    string ConcurrencyStamp { get; set; }
}