using Common.Base;
using Common.Base.Abstracts.Infrastructure;
using Domain.Entities.System;
using Domain.Entities.User;
using Domain.Repositories;
using MongoDB.Driver;

namespace Infrastructure.Database.Repositories;

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