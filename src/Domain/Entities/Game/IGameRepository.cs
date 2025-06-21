using Common.Base.Interfaces;
using Common.Base.Interfaces.Infrastructure;

namespace Domain.Entities.Game;

public interface IGameRepository : IRepository<Game>
{
    /// <summary>
    /// Asynchronously retrieves a game entity that matches the given identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the game to retrieve.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the operation to complete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the game entity that matches the specified identifier.</returns>
    Task<Game> GetToMatchByIdAsync(string id, CancellationToken cancellationToken);
}