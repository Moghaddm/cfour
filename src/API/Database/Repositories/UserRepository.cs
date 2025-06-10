using CFour.Base;
using CFour.Entities.System;
using CFour.Entities.User;
using MongoDB.Driver;

namespace CFour.Database.Repositories;

/// <inheritdoc cref="IUserRepository" /> 
public sealed class UserRepository(IMongoDatabase database) : Repository<User>(database), IUserRepository
{
    /// <inheritdoc cref="IUserRepository.LoadUserMatchingSpecAsync" /> 
    public async Task<SystemSpecification> LoadUserMatchingSpecAsync(string id, string systemSpecUnique,
        CancellationToken cancellationToken)
    {
        var filter = Builders<User>.Filter.And(
            Builders<User>.Filter.Eq(u => u.Id, id),
            Builders<User>.Filter.ElemMatch(u => u.SystemSpecifications,
                ss => ss.Unique == Guid.Parse(systemSpecUnique))
        );

        var projection = Builders<User>.Projection.Expression(user =>
            user.SystemSpecifications.FirstOrDefault(ss => ss.Unique == Guid.Parse(systemSpecUnique)));

        var systemSpecification =
            await Collection.Find(filter).Project(projection).FirstOrDefaultAsync(cancellationToken);

        return systemSpecification;
    }
}