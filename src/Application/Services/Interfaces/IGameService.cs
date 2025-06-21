using Application.DTOs.Game;

namespace Application.Services.Interfaces;

/// <summary>
/// Represents the contract for a service that manages game-related functionalities.
/// </summary>
public interface IGameService
{
    /// <summary>
    /// Asynchronously creates a new game using the provided details.
    /// </summary>
    /// <param name="dto">The data transfer object containing information about the game to be created.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task CreateAsync(CreateGameDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously deletes a game by its identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the game to be deleted.</param>
    /// <param name="deletedBy">The identifier of the user performing the deletion.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task DeleteAsync(string id, string deletedBy, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously updates an existing game with the provided details.
    /// </summary>
    /// <param name="id">The unique identifier of the game to be updated.</param>
    /// <param name="dto">The data transfer object containing updated information for the game.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UpdateAsync(string id, UpdateGameDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously retrieves a game's information by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the game to be retrieved.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, with a result of type <see cref="GameDto"/> containing the game's details.</returns>
    Task<GameDto> GetAsync(string id, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously retrieves a list of game previews filtered by the specified name.
    /// </summary>
    /// <param name="name">The optional name used to filter the games. If null, all games are retrieved.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of game previews.</returns>
    Task<List<GamePreviewDto>> GetAllAsync(string? name, CancellationToken cancellationToken);
}