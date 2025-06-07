using CFour.Base;

namespace CFour.Entities.Match;

/// <summary>
/// Represents a match entity that contains details about a game match, including associated user, system specification, and game information.
/// </summary>
/// <remarks>
/// Inherits from <see cref="BaseRemovableEntity"/> to include base entity features, auditing, and removal capabilities.
/// Contains a list of associated <see cref="Chat"/> objects for managing messages related to the match.
/// </remarks>
public sealed class Match : BaseRemovableEntity
{
    /// <summary>
    /// Represents a match entity containing details about a game match, including associated user information, system specification, game details, and a compatibility report.
    /// </summary>
    /// <remarks>
    /// The match entity is immutable except for the associated list of chats. It serves as a high-level aggregating object for linking users, a game's compatibility report, and system specifications.
    /// </remarks>
    public Match(string userId, string chosenSystemSpecificationUnique, string gameId, Report report)
    {
        Id = Guid.CreateVersion7().ToString();
        UserId = userId;
        ChosenSystemSpecificationUnique = chosenSystemSpecificationUnique;
        GameId = gameId;
        Report = report;
        Chats = [];
    }

    /// <summary>
    /// Gets the unique identifier of the user associated with the match.
    /// </summary>
    /// <remarks>
    /// This property holds the unique identifier of a user who participated or is related to the specific match.
    /// It is immutable and set during object initialization.
    /// </remarks>
    public string UserId { get; init; }

    /// <summary>
    /// Gets the unique identifier of the chosen system specification for the match.
    /// </summary>
    /// <remarks>
    /// This property represents the identifier of the system specification selected for the match.
    /// It is immutable and initialized during object creation.
    /// </remarks>
    public string ChosenSystemSpecificationUnique { get; init; }

    /// <summary>
    /// Gets the unique identifier of the game associated with the match.
    /// </summary>
    /// <remarks>
    /// This property represents the specific game linked to the match entity.
    /// It is immutable and is set during the initialization of the object.
    /// </remarks>
    public string GameId { get; init; }

    /// <summary>
    /// Gets or sets the compatibility report associated with the match.
    /// </summary>
    /// <remarks>
    /// This property contains detailed information about the system's ability to run the game associated with the match.
    /// The <see cref="Report"/> includes performance metrics, system compatibility evaluation,
    /// and recommendations for optimal game settings. It provides insights into potential bottlenecks and computes
    /// key indicators such as FPS estimates and hardware requirements matching.
    /// </remarks>
    public Report Report { get; init; }

    /// <summary>
    /// Gets or sets the collection of chat messages associated with the match.
    /// </summary>
    /// <remarks>
    /// This property holds a list of <see cref="Chat"/> objects that represent the messages exchanged during the match.
    /// It allows for managing communication and interactions associated with the specific match.
    /// </remarks>
    public IList<Chat> Chats { get; set; }
}