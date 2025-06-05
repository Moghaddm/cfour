using CFour.Base.Interfaces;
using CFour.Constants;
using MongoDB.Driver;

namespace CFour.Base;

/// <inheritdoc cref="IRepository{TId,TEntity}"/>
public class Repository<TId, TEntity>(IMongoDatabase database) : IRepository<TId, TEntity>
    where TEntity : IBaseEntity<TId>
{
    private readonly IMongoCollection<TEntity> _collection =
        database.GetCollection<TEntity>(DocumentConstants.UserCollectionName);

    /// <inheritdoc cref="IRepository{TId,TEntity}.AddAsync"/>
    public async Task AddAsync(TEntity document, CancellationToken cancellationToken)
    {
        if (document is BaseAuditedEntity<TId> auditedEntity)
        {
            auditedEntity.ModifiedAt = DateTime.UtcNow;
            auditedEntity.ModifiedBy = 0;
        }

        await _collection.InsertOneAsync(document, cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="IRepository{TId,TEntity}.RemoveAsync"/>
    public async Task RemoveAsync(TId id, TId? removerUserId, CancellationToken cancellationToken)
    {
        var filter = Builders<TEntity>.Filter.Eq(p => p.Id, id);

        if (typeof(IRemovableEntity<TId>).IsAssignableFrom(typeof(TEntity)))
        {
            var update = Builders<TEntity>.Update
                .Set(nameof(IRemovableEntity<TId>.RemovedAt), DateTime.UtcNow)
                .Set(nameof(IRemovableEntity<TId>.RemovedBy), removerUserId);

            await _collection.UpdateOneAsync(filter: filter, update: update, cancellationToken: cancellationToken);
        }
        else await _collection.DeleteOneAsync(filter: filter, cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="IRepository{TId,TEntity}.UpdateAsync"/>
    public async Task UpdateAsync(TId id, TEntity newEntity, TId? modifierUserId, CancellationToken cancellationToken)
    {
        var filter = Builders<TEntity>.Filter.Eq(p => p.Id, id);

        await _collection.ReplaceOneAsync(filter: filter, replacement: newEntity, cancellationToken: cancellationToken);

        if (typeof(IAuditedEntity<TId>).IsAssignableFrom(typeof(TEntity)))
        {
            var update = Builders<TEntity>.Update
                .Set(nameof(IAuditedEntity<TId>.ModifiedAt), DateTime.UtcNow)
                .Set(nameof(IAuditedEntity<TId>.ModifiedBy), modifierUserId);

            await _collection.UpdateOneAsync(filter: filter, update: update, cancellationToken: cancellationToken);
        }
    }

    /// <inheritdoc cref="IRepository{TId,TEntity}.GetAsync"/>
    public async Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken)
    {
        var filter = Builders<TEntity>.Filter.Eq(p => p.Id, id);

        return await _collection.Find(filter).FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="IRepository{TId,TEntity}.GetQueryable"/>
    public IQueryable<TEntity> GetQueryable()
    {
        return _collection.AsQueryable();
    }
}