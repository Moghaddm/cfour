using CFour.Base.Interfaces;

namespace CFour.Base;

/// <summary>
/// Represents a base implementation of an entity that supports soft deletion.
/// This class provides core properties to identify the entity, track concurrency,
/// and track removal details such as the user who performed the removal and the timestamp of removal.
/// </summary>
/// <remarks>
/// Inherits from <see cref="IRemovableEntity"/>. Implementation ensures that the entity
/// can be uniquely identified and supports tracking of soft deletion operations.
/// </remarks>
public abstract class BaseRemovableEntity : IRemovableEntity
{
    /// <inheritdoc cref="IBaseEntity.Id" />
    public string Id { get; init; } = null!;

    /// <inheritdoc cref="IBaseEntity.ConcurrencyStamp" />
    public string ConcurrencyStamp { get; set; } = null!;

    /// <inheritdoc cref="IBaseEntity.CreatorBy" />
    public string CreatorBy { get; set; } = null!;

    /// <inheritdoc cref="IBaseEntity.CreatedAt" />
    public DateTime CreatedAt { get; set; }

    /// <inheritdoc cref="IRemovableEntity.RemovedBy" />
    public long RemovedBy { get; set; }

    /// <inheritdoc cref="IRemovableEntity.RemovedAt" />
    public DateTime? RemovedAt { get; set; }
}