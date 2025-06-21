using Common.Base.Interfaces;
using Common.Base.Interfaces.Domain;

namespace Common.Base.Abstracts.Domain;

/// <summary>
/// Represents a base class for entities that have an active state.
/// Provides a unique identifier, a concurrency stamp for versioning,
/// and an active state toggle.
/// </summary>
public abstract class ActiveBasedEntity : IActiveBasedEntity
{
    /// <inheritdoc cref="IBaseEntity.Id" />
    public string Id { get; init; } = null!;

    /// <inheritdoc cref="IBaseEntity.ConcurrencyStamp" />
    public string ConcurrencyStamp { get; set; } = null!;

    /// <inheritdoc cref="IBaseEntity.CreatorBy" />
    public string CreatorBy { get; set; } = null!;

    /// <inheritdoc cref="IBaseEntity.CreatedAt" />
    public DateTime CreatedAt { get; set; }

    /// <inheritdoc cref="IActiveBasedEntity.IsActive" />
    public bool IsActive { get; set; } = true;
}