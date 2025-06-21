using Common.Base.Interfaces;
using Common.Base.Interfaces.Domain;

namespace Common.Base.Abstracts.Domain;

/// <summary>
/// Represents an abstract base class for entities that are designed to be audited,
/// incorporating details about modification and removal operations.
/// </summary>
/// <remarks>
/// Inherits properties from the <see cref="IAuditedEntity"/> interface to track
/// audit-related data, such as timestamps and user identifiers for modifications or removals.
/// Implements <see cref="IBaseEntity"/> to include basic entity properties.
/// </remarks>
public abstract class BaseAuditedEntity : IAuditedEntity
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

    /// <inheritdoc cref="IAuditedEntity.ModifiedBy" />
    public long ModifiedBy { get; set; }

    /// <inheritdoc cref="IAuditedEntity.ModifiedAt" />
    public DateTime ModifiedAt { get; set; }
}