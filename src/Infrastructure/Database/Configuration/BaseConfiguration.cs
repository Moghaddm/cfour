using Common.Base;
using Common.Base.Abstracts.Domain;
using Common.Base.Interfaces;
using Common.Base.Interfaces.Infrastructure;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Infrastructure.Database.Configuration;

public sealed class BaseConfiguration : IMongoConfiguration
{
    public void Configure()
    {
        BsonClassMap.RegisterClassMap<ActiveBasedEntity>(cm =>
        {
            cm.MapIdMember(g => g.Id).SetSerializer(new StringSerializer());
            cm.MapMember(abe => abe.ConcurrencyStamp);
            cm.MapMember(abe => abe.IsActive);
        });

        BsonClassMap.RegisterClassMap<BaseAuditedEntity>(cm =>
        {
            cm.MapIdMember(g => g.Id).SetSerializer(new StringSerializer());
            cm.MapMember(g => g.ConcurrencyStamp);
            cm.MapMember(g => g.RemovedBy);
            cm.MapMember(g => g.RemovedAt);
            cm.MapMember(g => g.ModifiedBy);
            cm.MapMember(g => g.ModifiedAt);
        });

        BsonClassMap.RegisterClassMap<BaseRemovableEntity>(cm =>
        {
            cm.MapIdMember(g => g.Id).SetSerializer(new StringSerializer());
            cm.MapMember(g => g.ConcurrencyStamp);
            cm.MapMember(g => g.RemovedBy);
            cm.MapMember(g => g.RemovedAt);
        });
    }
}