using Common.Base.Interfaces.Infrastructure;
using Domain.Entities.Game;
using Domain.Entities.User;

namespace Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    /// <summary>
    /// Asynchronously retrieves a machine setup for a user matching the provided unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <param name="machineUnique">The unique identifier of the system specification to be matched.</param>
    /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="GameSpecification"/> object representing the matching user system specification.</returns>
    Task<UserMachine> GetUserMachineByUniqueAsync(string id, string machineUnique, CancellationToken cancellationToken);
}