namespace CFour.Entities.Base;

public interface IBaseEntity<TId>
{
    TId Id { get; set; }
}

// public interface IBaseEntity<long> : IBaseEntity
// {
//     long Id { get; set; }
// }

