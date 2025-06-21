namespace Common.Base.Interfaces.Domain;

/// <summary>
/// Defines an interface for entities that support soft deletion functionality.
/// </summary>
/// <remarks>
/// Inherits from <see cref="IBaseEntity"/> and adds additional properties
/// to track information about when and by whom an entity was marked as removed.
/// </remarks>
public interface IRemovableEntity : IBaseEntity
{
    /// <summary>
    /// Represents the identifier of the user or entity responsible for removing the record.
    /// </summary>
    /// <remarks>
    /// This property typically stores the unique identifier of the actor (e.g., user or process)
    /// that initiated the removal of the associated entity. It is part of entities implementing
    /// the <see cref="IRemovableEntity"/> or derived interfaces/classes, providing traceability
    /// in systems where entity deletion or deactivation is tracked.
    /// </remarks>
    long RemovedBy { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was removed.
    /// </summary>
    /// <remarks>
    /// This property stores the timestamp indicating when the entity was marked as removed.
    /// It is typically used in conjunction with the <c>RemovedBy</c> property to track removal
    /// operations performed on the entity.
    /// </remarks>
    DateTime? RemovedAt { get; set; }
}