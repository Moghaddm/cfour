using Common.Base.Interfaces;
using Common.Base.Interfaces.Infrastructure;
using Domain.Entities.User;
using MongoDB.Bson.Serialization;

namespace Infrastructure.Database.Configuration;

public sealed class UserConfiguration : IMongoConfiguration
{
    public void Configure()
    {
        BsonClassMap.RegisterClassMap<User>(cm => { cm.AutoMap(); });
    }
}