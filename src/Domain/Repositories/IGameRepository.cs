using Common.Base.Interfaces.Infrastructure;
using Domain.Entities.Game;

namespace Domain.Repositories;

public interface IGameRepository : IRepository<Game>
{
    /// <summary>
    /// Asynchronously retrieves a game entity that matches the given identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the game to retrieve.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the operation to complete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the game entity that matches the specified identifier.</returns>
    Task<Game> GetCompareDataByIdAsync(string id, CancellationToken cancellationToken);
}