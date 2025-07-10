using Common.Base;
using Common.Base.Abstracts.Infrastructure;
using Domain.Entities.Compare;
using Domain.Repositories;
using MongoDB.Driver;

namespace Infrastructure.Database.Repositories;

public sealed class CompareRepository(IMongoDatabase database) : Repository<Compare>(database), ICompareRepository;