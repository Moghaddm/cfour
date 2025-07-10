using Common.Enums.System;

namespace Domain.Entities.Game.Specification;

/// <summary>
/// Represents an operating system with its associated properties such as type, version, build number, and architecture.
/// </summary>
public record struct OperatingSystem(
    OsType Type,
    string Version,
    OsArchitecture Architecture
);