using CFour.Base.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CFour.Base;

/// <summary>
/// Represents a base implementation of an entity that supports soft deletion.
/// This class provides core properties to identify the entity, track concurrency,
/// and track removal details such as the user who performed the removal and the timestamp of removal.
/// </summary>
/// <typeparam name="TId">
/// The type used for the identifier of the entity.
/// </typeparam>
/// <remarks>
/// Inherits from <see cref="IRemovableEntity{TId}"/>. Implementation ensures that the entity
/// can be uniquely identified and supports tracking of soft deletion operations.
/// </remarks>
public abstract class BaseRemovableEntity<TId> : IRemovableEntity<TId>
{
    /// <inheritdoc cref="IBaseEntity{TId}.Id" />
    public TId Id { get; init; } = default!;

    /// <inheritdoc cref="IBaseEntity{TId}.ConcurrencyStamp" />
    public string ConcurrencyStamp { get; set; } = null!;

    /// <inheritdoc cref="IRemovableEntity.RemovedBy" />
    public long RemovedBy { get; set; }

    /// <inheritdoc cref="IRemovableEntity.RemovedAt" />
    public DateTime? RemovedAt { get; set; }
}

/// <inheritdoc cref="BaseRemovableEntity{TId}" />
public abstract class BaseRemovableEntity : BaseAuditedEntity<string>
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public new string Id { get; set; } = null!;
}