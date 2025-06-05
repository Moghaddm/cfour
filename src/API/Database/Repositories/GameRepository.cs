using CFour.Entities.Game;
using MongoDB.Driver;

namespace CFour.Database.Repositories;

public sealed class GameRepository(IMongoDatabase database) : Repository<string, Game>(database), IGameRepository;