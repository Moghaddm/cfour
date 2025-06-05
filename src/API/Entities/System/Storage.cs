using CFour.Enums.System;

namespace CFour.Entities.System;

/// <summary>
/// Represents the storage subsystem of a system, providing information about
/// the main drive, storage capacity, and performance characteristics.
/// </summary>
public record struct Storage(
    int AvailableMb,
    StorageType Type
);