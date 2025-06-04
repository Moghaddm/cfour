namespace CFour.Base.Interfaces;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TId"></typeparam>
/// <typeparam name="TEntity"></typeparam>
public interface IRepository<TId, TEntity>
{
    string CollectionName { get; init; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="document"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TId> InsertOneAsync( TEntity document, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteOneAsync(TId id, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newEntity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateOneAsync(TId id, TEntity newEntity, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TEntity> GetOneAsync(TId id, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IList<TEntity>> GetQueryableAsync();
}