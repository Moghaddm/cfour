using CFour.Base;
using CFour.Entities.System;
using CFour.Entities.User;
using MongoDB.Driver;

namespace CFour.Database.Repositories;

public sealed class UserRepository(IMongoDatabase database) : Repository<string, User>(database), IUserRepository
{
    public Task<SystemSpecification> LoadUserMatchingSpecAsync(string id, string systemSpecUnique, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}