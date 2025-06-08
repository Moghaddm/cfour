using CFour.Base;
using CFour.Entities.Game;
using MongoDB.Driver;

namespace CFour.Database.Repositories;

public sealed class GameRepository(IMongoDatabase database) : Repository<Game>(database), IGameRepository
{
    public async Task<Game> GetToMatchByIdAsync(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<Game>.Filter.Eq(g => g.Id, id);

        var projection = Builders<Game>.Projection
            .Include(g => g.Title)
            .Include(g => g.Description)
            .Include(g => g.MinimumRequirement)
            .Include(g => g.RecommendedRequirement)
            .Exclude(g => g.Id);

        var game = await Collection
            .Find(filter)
            .Project<Game>(projection)
            .FirstOrDefaultAsync(cancellationToken);

        return game;
    }
}