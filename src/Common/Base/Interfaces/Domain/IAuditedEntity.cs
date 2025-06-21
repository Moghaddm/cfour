namespace Common.Base.Interfaces.Domain;

public interface IAuditedEntity : IRemovableEntity
{
    /// <summary>
    /// Gets or sets the identifier of the user who last modified the entity.
    /// </summary>
    /// <remarks>
    /// This property is used for tracking the user responsible for the most recent modification
    /// to the entity. Typically, it stores the unique identifier of the user.
    /// </remarks>
    long ModifiedBy { get; set; }

    /// <summary>
    /// Gets or sets the timestamp indicating when the entity was last modified.
    /// </summary>
    /// <remarks>
    /// This property is used to track the date and time of the most recent modification
    /// to the entity. It is typically set automatically during update operations.
    /// </remarks>
    DateTime ModifiedAt { get; set; }
}