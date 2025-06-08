using CFour.Base.Interfaces;
using CFour.Entities.Game;
using MongoDB.Bson.Serialization;

namespace CFour.Database.Configuration;

public sealed class GameConfiguration : IMongoConfiguration
{
    public void Configure()
    {
        BsonClassMap.RegisterClassMap<Game>(cm =>
        {
            cm.AutoMap();
            cm.MapCreator(game => new Game(
                game.Title,
                game.Description,
                game.PhotoIds,
                game.TrailerIds,
                game.Genre,
                game.Developer,
                game.Publisher,
                game.ReleaseDate,
                game.OfficialWebsite,
                game.Rating,
                game.AvailablePlatforms,
                game.Tags,
                game.MinimumRequirement,
                game.RecommendedRequirement)
            );
        });
    }
}