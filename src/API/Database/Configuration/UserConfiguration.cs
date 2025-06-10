using CFour.Base.Interfaces;
using CFour.Entities.User;
using MongoDB.Bson.Serialization;

namespace CFour.Database.Configuration;

public sealed class UserConfiguration : IMongoConfiguration
{
    public void Configure()
    {
        BsonClassMap.RegisterClassMap<User>(cm => { cm.AutoMap(); });
    }
}