using CFour.Base.Interfaces;

namespace CFour.Base;

/// <summary>
/// Represents a base class for entities that have an active state.
/// Provides a unique identifier, a concurrency stamp for versioning,
/// and an active state toggle.
/// </summary>
/// <typeparam name="TId">
/// The type of the unique identifier for the entity.
/// </typeparam>
public abstract class ActiveBasedEntity<TId> : IActiveBasedEntity<TId>
{
    /// <inheritdoc cref="IBaseEntity{TId}.Id" />
    public required TId Id { get; init; }

    /// <inheritdoc cref="IBaseEntity{TId}.ConcurrencyStamp" />
    public required string ConcurrencyStamp { get; set; }

    /// <inheritdoc cref="IActiveBasedEntity{TId}.IsActive" />
    public required bool IsActive { get; set; }
}

public abstract class ActiveBasedEntity : ActiveBasedEntity<long>;