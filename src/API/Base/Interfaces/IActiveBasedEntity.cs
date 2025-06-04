namespace CFour.Base.Interfaces;

/// <summary>
/// Represents an entity that has an active state indicator.
/// </summary>
/// <typeparam name="TId">
/// The type of the unique identifier for the entity.
/// </typeparam>
public interface IActiveBasedEntity<TId> : IBaseEntity<TId>
{
    /// <summary>
    /// Indicates whether the entity is active or inactive.
    /// </summary>
    /// <remarks>
    /// This property is commonly used to determine the logical state of an entity,
    /// enabling soft deletes or distinguishing active records from inactive ones.
    /// </remarks>
    public bool IsActive { get; set; }
}

/// <inheritdoc cref="IActiveBasedEntity{TId}"/>
public interface IActiveBasedEntity : IActiveBasedEntity<long>;
