namespace CFour.Base.Interfaces;

/// <summary>
/// Provides a base interface for a repository pattern to perform CRUD operations
/// on a specific data entity.
/// </summary>
/// <typeparam name="TId">The type of the identifier for the entity.</typeparam>
/// <typeparam name="TEntity">The type of the entity managed by the repository.</typeparam>
public interface IRepository<in TId, TEntity>
{
    /// <summary>
    /// Asynchronously inserts a single document into the collection.
    /// </summary>
    /// <param name="document">The document to be inserted into the collection.</param>
    /// <param name="cancellationToken">The token that can be used to cancel the operation.</param>
    /// <returns>A task representing the asynchronous insert operation.</returns>
    Task AddAsync(TEntity document, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously deletes a single document from the collection by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the document to delete.</param>
    /// <param name="cancellationToken">The token that can be used to cancel the operation.</param>
    /// <returns>A task representing the asynchronous delete operation.</returns>
    Task RemoveAsync(TId id, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously updates a single document in the collection with a specified replacement entity.
    /// </summary>
    /// <param name="id">The identifier of the document to update.</param>
    /// <param name="newEntity">The new entity object that will replace the existing document.</param>
    /// <param name="cancellationToken">The token that can be used to cancel the operation.</param>
    /// <returns>A task representing the asynchronous update operation.</returns>
    Task UpdateAsync(TId id, TEntity newEntity, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously retrieves a single document from the collection by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the document to retrieve.</param>
    /// <param name="cancellationToken">The token that can be used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous retrieval operation. The task result contains the retrieved document, or null if not found.</returns>
    Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a queryable collection of entities managed by the repository.
    /// </summary>
    /// <returns>A queryable collection of entities.</returns>
    IQueryable<TEntity> GetQueryable();
}