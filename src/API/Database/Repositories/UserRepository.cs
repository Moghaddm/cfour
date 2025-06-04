using CFour.Entities.User;
using MongoDB.Driver;

namespace CFour.Database.Repositories;

public sealed class UserRepository(IMongoDatabase database) : Repository<long, User>(database), IUserRepository;