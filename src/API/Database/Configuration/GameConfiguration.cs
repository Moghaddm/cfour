using CFour.Base.Interfaces;
using CFour.Entities.Game;
using MongoDB.Bson.Serialization;

namespace CFour.Database.Configuration;

public sealed class GameConfiguration : IMongoConfiguration
{
    public void Configure()
    {
        BsonClassMap.RegisterClassMap<Game>(cm => { cm.AutoMap(); });
    }
}