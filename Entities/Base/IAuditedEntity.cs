namespace CFour.Entities.Base;

public interface IAuditedEntity : IRemovableEntity
{
    long ModifiedBy { get; set; }
    DateTime ModifiedAt { get; set; }
}