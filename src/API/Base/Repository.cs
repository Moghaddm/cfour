using CFour.Base.Interfaces;
using MongoDB.Driver;

namespace CFour.Base;

/// <inheritdoc cref="IRepository{TEntity}"/>
public class Repository<TEntity>(IMongoDatabase database) : IRepository<TEntity> where TEntity : IBaseEntity
{
    protected readonly IMongoCollection<TEntity> Collection =
        database.GetCollection<TEntity>(typeof(TEntity).ToString().Split('.').Last());

    /// <inheritdoc cref="IRepository{TEntity}.AddAsync"/>
    public async Task AddAsync(TEntity document, CancellationToken cancellationToken)
    {
        if (document is BaseAuditedEntity auditedEntity)
        {
            auditedEntity.CreatedAt = DateTime.UtcNow;
            auditedEntity.ModifiedAt = DateTime.UtcNow;
            auditedEntity.ModifiedBy = 0;
        }

        await Collection.InsertOneAsync(document, cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="IRepository{TEntity}.RemoveAsync"/>
    public async Task RemoveAsync(string id, string? removerUserId, CancellationToken cancellationToken)
    {
        var filter = Builders<TEntity>.Filter.Eq(p => p.Id, id);

        if (typeof(IRemovableEntity).IsAssignableFrom(typeof(TEntity)))
        {
            var update = Builders<TEntity>.Update
                .Set(nameof(IRemovableEntity.RemovedAt), DateTime.UtcNow)
                .Set(nameof(IRemovableEntity.RemovedBy), removerUserId);

            await Collection.UpdateOneAsync(filter: filter, update: update, cancellationToken: cancellationToken);
        }
        else await Collection.DeleteOneAsync(filter: filter, cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="IRepository{TEntity}.UpdateAsync"/>
    public async Task UpdateAsync(string id, TEntity newEntity, string? modifierUserId,
        CancellationToken cancellationToken)
    {
        var filter = Builders<TEntity>.Filter.Eq(p => p.Id, id);

        await Collection.ReplaceOneAsync(filter: filter, replacement: newEntity, cancellationToken: cancellationToken);

        if (typeof(IAuditedEntity).IsAssignableFrom(typeof(TEntity)))
        {
            var update = Builders<TEntity>.Update
                .Set(nameof(IAuditedEntity.ModifiedAt), DateTime.UtcNow)
                .Set(nameof(IAuditedEntity.ModifiedBy), modifierUserId);

            await Collection.UpdateOneAsync(filter: filter, update: update, cancellationToken: cancellationToken);
        }
    }

    /// <inheritdoc cref="IRepository{TEntity}.GetAsync"/>
    public async Task<TEntity> GetAsync(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<TEntity>.Filter.Eq(p => p.Id, id);

        return await Collection.Find(filter).FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="IRepository{TEntity}.GetQueryable"/>
    public IQueryable<TEntity> GetQueryable()
    {
        return Collection.AsQueryable();
    }
}