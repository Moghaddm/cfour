using CFour.Base.Interfaces;

namespace CFour.Base;

/// <summary>
/// Represents a base class for entities that have an active state.
/// Provides a unique identifier, a concurrency stamp for versioning,
/// and an active state toggle.
/// </summary>
public abstract class ActiveBasedEntity : IActiveBasedEntity
{
    /// <inheritdoc cref="IBaseEntity.Id" />
    public string Id { get; init; } = default!;

    /// <inheritdoc cref="IBaseEntity.ConcurrencyStamp" />
    public string ConcurrencyStamp { get; set; } = null!;

    /// <inheritdoc cref="IActiveBasedEntity.IsActive" />
    public bool IsActive { get; set; } = true;
}