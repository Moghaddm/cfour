using Common.Base.Abstracts.Infrastructure;
using Domain.Entities.User;
using Domain.Repositories;
using Infrastructure.Database.Exceptions;
using MongoDB.Driver;

namespace Infrastructure.Database.Repositories;

/// <inheritdoc cref="IUserRepository" /> 
public sealed class UserRepository(IMongoDatabase database) : Repository<User>(database), IUserRepository
{
    /// <inheritdoc cref="IUserRepository.GetUserMachineByUniqueAsync" /> 
    public async Task<UserMachine> GetUserMachineByUniqueAsync(string id, string machineUnique,
        CancellationToken cancellationToken)
    {
        var filter = Builders<User>.Filter.And(
            Builders<User>.Filter.Eq(u => u.Id, id),
            Builders<User>.Filter.ElemMatch(u => u.Machines, um => um.Unique == machineUnique)
        );

        var projection =
            Builders<User>.Projection.Expression(user =>
                user.Machines.FirstOrDefault(um => um.Unique == machineUnique));

        var machine =
            await Collection.Find(filter).Project(projection).FirstOrDefaultAsync(cancellationToken);

        if (machine is null) throw new EntityNotFoundException(nameof(User), id);

        return machine;
    }
}