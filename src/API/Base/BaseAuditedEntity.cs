using CFour.Base.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CFour.Base;

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
    public TId Id { get; init; } = default!;

    /// <inheritdoc cref="IBaseEntity{TId}.ConcurrencyStamp" />
    public string ConcurrencyStamp { get; set; } = null!;

    /// <inheritdoc cref="IRemovableEntity.RemovedBy" />
    public long RemovedBy { get; set; }

    /// <inheritdoc cref="IRemovableEntity.RemovedAt" />
    public DateTime? RemovedAt { get; set; }

    /// <inheritdoc cref="IAuditedEntity.ModifiedBy" />
    public long ModifiedBy { get; set; }

    /// <inheritdoc cref="IAuditedEntity.ModifiedAt" />
    public DateTime ModifiedAt { get; set; }
}

public abstract class BaseAuditedEntity : BaseAuditedEntity<string>
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public new string Id { get; set; } = null!;
}