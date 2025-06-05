using CFour.Enums.System;

namespace CFour.Entities.System;

/// <summary>
/// Represents an operating system with its associated properties such as type, version, build number, and architecture.
/// </summary>
public struct OperationSystem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OperationSystem"/> struct with specified properties.
    /// </summary>
    /// <param name="type">The type of the operating system.</param>
    /// <param name="version">The version of the operating system.</param>
    /// <param name="buildNumber">The build number of the operating system.</param>
    /// <param name="architecture">The architecture of the operating system.</param>
    public OperationSystem(OsType type, string version, int buildNumber, OsArchitecture architecture)
    {
        Type = type;
        Version = version;
        BuildNumber = buildNumber;
        Architecture = architecture;
    }

    /// <summary>
    /// Gets or sets the operating system type.
    /// </summary>
    public OsType Type { get; init; }

    /// <summary>
    /// Gets or sets the version of the operating system.
    /// </summary>
    public string Version { get; init; } = null!;

    /// <summary>
    /// Gets or sets the build number of the operating system.
    /// </summary>
    public int BuildNumber { get; init; }

    /// <summary>
    /// Gets or sets the architecture of the operating system.
    /// </summary>
    public OsArchitecture Architecture { get; init; }
}