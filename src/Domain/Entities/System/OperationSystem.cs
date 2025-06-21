using Common.Enums.System;

namespace Domain.Entities.System;

/// <summary>
/// Represents an operating system with its associated properties such as type, version, build number, and architecture.
/// </summary>
public record struct OperationSystem(
    OsType Type,
    string Version,
    OsArchitecture Architecture
);