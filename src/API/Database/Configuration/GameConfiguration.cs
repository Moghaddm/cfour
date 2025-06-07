using CFour.Base;
using MongoDB.Bson.Serialization;

namespace CFour.Database.Configuration;

public static class GameConfiguration
{
    public static void RegisterMappings()
    {
        BsonClassMap.RegisterClassMap<ActiveBasedEntity>(cm =>
        {
            cm.AutoMap();
            cm.MapIdMember(c => c.Id)
                .SetIsRequired(true);
            cm.SetIgnoreExtraElements(true);
        });
    }
}