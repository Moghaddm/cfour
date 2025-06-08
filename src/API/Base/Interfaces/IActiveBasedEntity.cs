namespace CFour.Base.Interfaces;

/// <summary>
/// Defines an entity that includes an active state property.
/// </summary>
/// <remarks>
/// This interface extends <see cref="IBaseEntity"/> by introducing the ability to
/// determine whether the entity is active through the <c>IsActive</c> property.
/// Useful in scenarios where entities need to be soft-enabled or disabled
/// within a system without physical deletion.
/// </remarks>
public interface IActiveBasedEntity : IBaseEntity
{
    /// <summary>
    /// Indicates whether the entity is active or inactive.
    /// </summary>
    /// <remarks>
    /// This property is commonly used to determine the logical state of an entity,
    /// enabling soft deletes or distinguishing active records from inactive ones.
    /// </remarks>
    public bool IsActive { get; set; }
}