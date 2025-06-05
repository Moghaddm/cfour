using CFour.Base.Interfaces;
using CFour.Constants;
using MongoDB.Driver;

namespace CFour.Database.Repositories;

/// <inheritdoc cref="IRepository{TId,TEntity}"/>
public class Repository<TId, TEntity>(IMongoDatabase database) : IRepository<TId, TEntity>
    where TEntity : IBaseEntity<TId>
{
    private readonly IMongoCollection<TEntity> _collection =
        database.GetCollection<TEntity>(DocumentConstants.UserCollectionName);

    /// <inheritdoc cref="IRepository{TId,TEntity}.AddAsync"/>
    public async Task AddAsync(TEntity document, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(document, cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="IRepository{TId,TEntity}.RemoveAsync"/>
    public async Task RemoveAsync(TId id, CancellationToken cancellationToken)
    {
        var filter = Builders<TEntity>.Filter.Eq(p => p.Id, id);
        await _collection.DeleteOneAsync(filter: filter, cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="IRepository{TId,TEntity}.UpdateAsync"/>
    public async Task UpdateAsync(TId id, TEntity newEntity, CancellationToken cancellationToken)
    {
        var filter = Builders<TEntity>.Filter.Eq(p => p.Id, id);
        await _collection.ReplaceOneAsync(filter: filter, replacement: newEntity, cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="IRepository{TId,TEntity}.GetAsync"/>
    public async Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken)
    {
        var filter = Builders<TEntity>.Filter.Eq(p => p.Id, id);
        var document = await _collection.Find(filter).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        return document;
    }

    /// <inheritdoc cref="IRepository{TId,TEntity}.GetQueryable"/>
    public IQueryable<TEntity> GetQueryable()
    {
        return _collection.AsQueryable();
    }
}