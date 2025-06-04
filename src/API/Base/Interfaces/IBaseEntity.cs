namespace CFour.Base.Interfaces;

/// <summary>
/// Defines a base entity structure with a generic identifier.
/// </summary>
/// <typeparam name="TId">
/// Type of the identifier property for the entity.
/// </typeparam>
public interface IBaseEntity<TId>
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    TId Id { get; init; }

    /// <summary>
    /// Gets or sets the concurrency token used to handle optimistic concurrency control scenarios.
    /// </summary>
    string ConcurrencyStamp { get; set; }
}

/// <inheritdoc cref="IBaseEntity{TId}"/>
public interface IBaseEntity : IBaseEntity<long>;