using CFour.Base.Interfaces;
using CFour.Entities.System;

namespace CFour.Entities.User;

public interface IUserRepository : IRepository<string, User>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="systemSpecUnique"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SystemSpecification> LoadUserMatchingSpecAsync(string id, string systemSpecUnique,
        CancellationToken cancellationToken);
}