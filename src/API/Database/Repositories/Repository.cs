using CFour.Base.Interfaces;
using MongoDB.Driver;

namespace CFour.Database.Repositories;

public class Repository<TId, TEntity> : IRepository<TId, TEntity>
{
    public string CollectionName { get; init; } = "";
    private IMongoCollection<TEntity> _collection;

    public Repository(IMongoDatabase database)
    {
        _collection = database.GetCollection<TEntity>(CollectionName);
    }

    public async Task<TId> InsertOneAsync(TEntity document, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(document, cancellationToken);

        return default;
    }

    public Task DeleteOneAsync(TId id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOneAsync(TId id, TEntity newEntity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetOneAsync(TId id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IList<TEntity>> GetQueryableAsync()
    {
        throw new NotImplementedException();
    }
}