namespace Domain.Entities.Game.Specification;

/// <summary>
/// Represents the memory information of a system, including physical and virtual memory details.
/// </summary>
public record struct Memory(
    int RamTotalMb,
    int VRamTotalMb
);