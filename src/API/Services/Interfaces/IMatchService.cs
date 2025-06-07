using CFour.DTOs.Match;

namespace CFour.Services.Interfaces;

/// <summary>
/// Defines the operations for managing match-related services.
/// </summary>
public interface IMatchService
{
    /// <summary>
    /// Initiates a match process based on the provided input data and returns the identifier of the created or matched entity.
    /// </summary>
    /// <param name="inDto">The input data transfer object containing match details including game ID, user ID, and system specifications.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>Returns a task that represents the asynchronous operation. The task result contains the GUID of the created or matched entity as string value.</returns>
    Task<string> MatchAsync(MatchInDto inDto, CancellationToken cancellationToken);
}