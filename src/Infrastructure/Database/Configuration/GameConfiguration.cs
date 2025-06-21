using Common.Base.Interfaces;
using Common.Base.Interfaces.Infrastructure;
using Domain.Entities.Game;
using MongoDB.Bson.Serialization;

namespace Infrastructure.Database.Configuration;

public sealed class GameConfiguration : IMongoConfiguration
{
    public void Configure()
    {
        BsonClassMap.RegisterClassMap<Game>(cm => { cm.AutoMap(); });
    }
}