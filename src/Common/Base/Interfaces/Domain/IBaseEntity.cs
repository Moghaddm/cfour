namespace Common.Base.Interfaces.Domain;

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

    /// <summary>
    /// Gets or sets the identifier of the user who created the entity.
    /// </summary>
    public string CreatorBy { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}