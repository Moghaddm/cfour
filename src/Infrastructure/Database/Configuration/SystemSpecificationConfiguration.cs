using Common.Base.Interfaces;
using Common.Base.Interfaces.Infrastructure;
using Domain.Entities.System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Infrastructure.Database.Configuration;

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