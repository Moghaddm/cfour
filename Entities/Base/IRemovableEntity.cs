namespace CFour.Entities.Base;

public interface IRemovableEntity : IBaseEntity
{
    string ConcurrencyStamp { get; set; }
    long RemovedBy { get; set; }
    DateTime RemovedAt { get; set; }
}