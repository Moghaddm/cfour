using CFour.Base;
using CFour.Entities.Match;
using MongoDB.Driver;

namespace CFour.Database.Repositories;

public sealed class MatchRepository(IMongoDatabase database) : Repository<string, Match>(database), IMatchRepository;