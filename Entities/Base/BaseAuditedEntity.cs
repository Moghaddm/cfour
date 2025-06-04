using CFour.Entities.Base.Interfaces;

namespace CFour.Entities.Base;

/// <summary>
/// Represents an abstract base class for entities that are designed to be audited,
/// incorporating details about modification and removal operations.
/// </summary>
/// <remarks>
/// Inherits properties from the <see cref="IAuditedEntity"/> interface to track
/// audit-related data, such as timestamps and user identifiers for modifications or removals.
/// Implements <see cref="IBaseEntity"/> to include basic entity properties.
/// </remarks>
public abstract class BaseAuditedEntity<TId> : IAuditedEntity<TId>
{
    /// <inheritdoc cref="IBaseEntity{TId}.Id" />
    public required TId Id { get; init; }

    /// <inheritdoc cref="IBaseEntity{TId}.ConcurrencyStamp" />
    public required string ConcurrencyStamp { get; set; } = null!;

    /// <inheritdoc cref="IRemovableEntity.RemovedBy" />
    public required long RemovedBy { get; set; }

    /// <inheritdoc cref="IRemovableEntity.RemovedAt" />
    public required DateTime? RemovedAt { get; set; }

    /// <inheritdoc cref="IAuditedEntity.ModifiedBy" />
    public required long ModifiedBy { get; set; }

    /// <inheritdoc cref="IAuditedEntity.ModifiedAt" />
    public required DateTime ModifiedAt { get; set; }
}

public abstract class BaseAuditedEntity : BaseAuditedEntity<long>;