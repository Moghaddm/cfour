using Common.Base;
using Common.Base.Abstracts.Infrastructure;
using Domain.Entities.Match;
using Domain.Repositories;
using MongoDB.Driver;

namespace Infrastructure.Database.Repositories;

public sealed class MatchRepository(IMongoDatabase database) : Repository<Match>(database), IMatchRepository;