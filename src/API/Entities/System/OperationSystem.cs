using CFour.Enums.System;

namespace CFour.Entities.System;

/// <summary>
/// Represents an operating system with its associated properties such as type, version, build number, and architecture.
/// </summary>
public sealed class OperationSystem
{
    /// <summary>
    /// Gets or sets the operating system type.
    /// </summary>
    public OsType Type { get; set; }

    /// <summary>
    /// Gets or sets the version of the operating system.
    /// </summary>
    public string Version { get; set; } = null!;

    /// <summary>
    /// Gets or sets the build number of the operating system.
    /// </summary>
    public int BuildNumber { get; set; }

    /// <summary>
    /// Gets or sets the architecture of the operating system.
    /// </summary>
    public OsArchitecture Architecture { get; set; }
}