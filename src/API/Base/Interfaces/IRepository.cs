namespace CFour.Base.Interfaces;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TId"></typeparam>
/// <typeparam name="TEntity"></typeparam>
public interface IRepository<TId, TEntity>
{
    /// <summary>
    /// Asynchronously inserts a single document into the collection.
    /// </summary>
    /// <param name="document">The document to be inserted into the collection.</param>
    /// <param name="cancellationToken">The token that can be used to cancel the operation.</param>
    /// <returns>A task representing the asynchronous insert operation.</returns>
    Task InsertOneAsync(TEntity document, CancellationToken cancellationToken);

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
    IQueryable<TEntity> GetQueryable();
}