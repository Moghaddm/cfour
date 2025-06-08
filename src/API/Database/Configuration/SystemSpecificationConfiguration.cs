using CFour.Base.Interfaces;
using CFour.Entities.System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace CFour.Database.Configuration;

public sealed class SystemSpecificationConfiguration : IMongoConfiguration
{
    public void Configure()
    {
        BsonClassMap.RegisterClassMap<SystemSpecification>(cm =>
        {
            cm.AutoMap();
            cm.MapMember(ss => ss.Unique).SetSerializer(new GuidSerializer(GuidRepresentation.Standard));
        });
    }
}