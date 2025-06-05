using CFour.Base.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

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
    public TId Id { get; init; } = default!;

    /// <inheritdoc cref="IBaseEntity{TId}.ConcurrencyStamp" />
    public string ConcurrencyStamp { get; set; } = null!;

    /// <inheritdoc cref="IActiveBasedEntity{TId}.IsActive" />
    public bool IsActive { get; set; } = true;
}

public abstract class ActiveBasedEntity : ActiveBasedEntity<string>
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public new string Id { get; set; } = null!;
}