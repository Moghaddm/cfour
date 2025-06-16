using CFour.Base;
using CFour.Base.Interfaces;
using CFour.Entities.System;
using CFour.Enums.Game;

namespace CFour.Entities.Game;

/// <summary>
/// Represents a game with properties describing its details, media, and availability.
/// </summary>
public sealed class Game : ActiveBasedEntity, ICreatableEntity
{
    /// <summary>
    /// Represents a game entity with detailed information, including title, description, genre,
    /// developer, publisher, release date, platform availability, system requirements, and more.
    /// </summary>
    public Game(string title, string description, List<string> photoIds, List<string> trailerIds, GameGenre genre,
        string developer, string publisher, DateTime releaseDate, string officialWebsite, double rating,
        IList<GamePlatform> availablePlatforms, IList<string> tags, SystemSpecification minimumRequirement,
        SystemSpecification recommendedRequirement, string creatorBy)
    {
        Id = Guid.CreateVersion7().ToString();
        ConcurrencyStamp = Guid.CreateVersion7().ToString();
        Title = title;
        Description = description;
        PhotoIds = photoIds;
        TrailerIds = trailerIds;
        Genre = genre;
        Developer = developer;
        Publisher = publisher;
        ReleaseDate = releaseDate;
        OfficialWebsite = officialWebsite;
        Rating = rating;
        AvailablePlatforms = availablePlatforms;
        Tags = tags;
        MinimumRequirement = minimumRequirement;
        RecommendedRequirement = recommendedRequirement;
        CreatorBy = creatorBy;
    }

    /// <summary>
    /// Gets or sets the title of the game.
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// Gets or sets the description of the game.
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Gets or sets the list of photo IDs associated with the game.
    /// </summary>
    public List<string> PhotoIds { get; private set; }

    /// <summary>
    /// Gets or sets the collection of identifiers for the trailers associated with the game.
    /// </summary>
    public List<string> TrailerIds { get; private set; }

    /// <summary>
    /// Gets or sets the genre of the game.
    /// </summary>
    public GameGenre Genre { get; private set; }

    /// <summary>
    /// Gets or sets the name of the developer responsible for creating the game.
    /// </summary>
    public string Developer { get; private set; }

    /// <summary>
    /// Gets or sets the publisher of the game.
    /// </summary>
    public string Publisher { get; private set; }

    /// <summary>
    /// Gets or sets the release date of the game.
    /// </summary>
    public DateTime ReleaseDate { get; private set; }

    /// <summary>
    /// Gets or sets the official website of the game.
    /// </summary>
    public string OfficialWebsite { get; private set; }

    /// <summary>
    /// Gets or sets the rating of the game.
    /// </summary>
    public double Rating { get; private set; }

    /// <summary>
    /// Gets or sets the list of platforms on which the game is available.
    /// </summary>
    public IList<GamePlatform> AvailablePlatforms { get; private set; }

    /// <summary>
    /// Gets or sets the collection of tags associated with the game.
    /// </summary>
    public IList<string> Tags { get; private set; }

    /// <summary>
    /// Gets or sets the system specifications required to run the game at minimum settings.
    /// </summary>
    public SystemSpecification MinimumRequirement { get; private set; }

    /// <summary>
    /// Gets or sets the recommended system specifications for running the game.
    /// </summary>
    public SystemSpecification RecommendedRequirement { get; private set; }
}