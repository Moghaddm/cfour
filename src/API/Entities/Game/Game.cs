using CFour.Entities.Base;
using CFour.Entities.System;
using CFour.Enums.Game;

namespace CFour.Entities.Game;

/// <summary>
/// Represents a game with properties describing its details, media, and availability.
/// </summary>
public sealed class Game : ActiveBasedEntity
{
    /// <summary>
    /// Gets or sets the title of the game.
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Gets or sets the description of the game.
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Gets or sets the list of photo IDs associated with the game.
    /// </summary>
    public List<long> PhotoIds { get; set; } = null!;

    /// <summary>
    /// Gets or sets the collection of identifiers for the trailers associated with the game.
    /// </summary>
    public List<long> TrailerIds { get; set; } = null!;

    /// <summary>
    /// Gets or sets the genre of the game.
    /// </summary>
    public GameGenre Genre { get; set; }

    /// <summary>
    /// Gets or sets the name of the developer responsible for creating the game.
    /// </summary>
    public string Developer { get; set; } = null!;

    /// <summary>
    /// Gets or sets the publisher of the game.
    /// </summary>
    public string Publisher { get; set; } = null!;

    /// <summary>
    /// Gets or sets the release date of the game.
    /// </summary>
    public DateTime ReleaseDate { get; set; }

    /// <summary>
    /// Gets or sets the official website of the game.
    /// </summary>
    public string OfficialWebsite { get; set; } = null!;

    /// <summary>
    /// Gets or sets the rating of the game.
    /// </summary>
    public double Rating { get; set; }

    /// <summary>
    /// Gets or sets the list of platforms on which the game is available.
    /// </summary>
    public IList<GamePlatform> AvailablePlatforms { get; set; } = null!;

    /// <summary>
    /// Gets or sets the collection of tags associated with the game.
    /// </summary>
    public IList<string> Tags { get; set; } = null!;

    /// <summary>
    /// Gets or sets the system specifications required to run the game at minimum settings.
    /// </summary>
    public SystemSpecification MinimumRequirement { get; set; } = null!;

    /// <summary>
    /// Gets or sets the recommended system specifications for running the game.
    /// </summary>
    public SystemSpecification RecommendedRequirement { get; set; } = null!;

    /// <summary>
    /// Gets or sets the high system requirements for running the game.
    /// This property provides detailed specifications, including processor, memory, GPU, and other hardware or software components required for optimal performance.
    /// </summary>
    public SystemSpecification HighRequirement { get; set; } = null!;
}