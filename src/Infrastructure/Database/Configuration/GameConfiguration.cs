using Common.Base.Interfaces.Infrastructure;
using Domain.Entities.Game;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Infrastructure.Database.Configuration;

public sealed class GameConfiguration : IMongoConfiguration
{
    public void Configure()
    {
        BsonClassMap.RegisterClassMap<Game>(cm => { cm.AutoMap(); });

        BsonClassMap.RegisterClassMap<GameSpecification>(cm =>
        {
            cm.AutoMap();
            cm.MapMember(gs => gs.Unique).SetSerializer(new GuidSerializer(GuidRepresentation.Standard));
        });
    }
}