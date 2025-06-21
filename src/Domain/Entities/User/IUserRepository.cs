using Common.Base.Interfaces;
using Common.Base.Interfaces.Infrastructure;
using Domain.Entities.System;

namespace Domain.Entities.User;

public interface IUserRepository : IRepository<User>
{
    /// <summary>
    /// Asynchronously retrieves a system specification for a user matching the provided specification identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <param name="systemSpecUnique">The unique identifier of the system specification to be matched.</param>
    /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="SystemSpecification"/> object representing the matching user system specification.</returns>
    Task<SystemSpecification> LoadUserMatchingSpecAsync(string id, string systemSpecUnique,
        CancellationToken cancellationToken);
}