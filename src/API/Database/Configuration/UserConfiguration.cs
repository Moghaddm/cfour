using CFour.Base.Interfaces;
using CFour.Entities.User;
using MongoDB.Bson.Serialization;

namespace CFour.Database.Configuration;

public sealed class UserConfiguration : IMongoConfiguration
{
    public void Configure()
    {
        BsonClassMap.RegisterClassMap<User>(cm =>
        {
            cm.AutoMap();
            cm.MapCreator(user => new User(
                user.Id,    
                user.ConcurrencyStamp,
                user.FirstName,
                user.LastName,
                user.Email,
                user.PhoneNumber,
                user.AvatarAttachmentId,
                user.SystemSpecifications)
            );
        });
    }
}