using CFour.Base;
using CFour.Entities.System;
using CFour.Entities.User;
using MongoDB.Driver;

namespace CFour.Database.Repositories;

public sealed class UserRepository(IMongoDatabase database) : Repository<string, User>(database), IUserRepository
{
    public async Task<SystemSpecification> LoadUserMatchingSpecAsync(string id, string systemSpecUnique,
        CancellationToken cancellationToken)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Id, id);
        var projection = Builders<User>.Projection.Include(u =>
            u.SystemSpecifications.Where(x => x.Unique.ToString() == systemSpecUnique));

        var user =
            await Collection.Find(filter).Project(projection).ToListAsync(cancellationToken);

        throw new NotImplementedException();
    }
}