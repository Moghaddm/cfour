using CFour.Enums.System;

namespace CFour.Entities.System;

/// <summary>
/// Represents the memory information of a system, including physical and virtual memory details.
/// </summary>
public struct Memory
{
    /// <summary>
    /// Represents the memory information of a system, including physical and virtual memory details.
    /// </summary>
    public Memory(int totalPhysicalMb, int totalVirtualMb, MemoryType type, int speedMHz)
    {
        TotalPhysicalMb = totalPhysicalMb;
        TotalVirtualMb = totalVirtualMb;
        Type = type;
        SpeedMHz = speedMHz;
    }

    /// <summary>
    /// Gets or sets the total amount of physical memory available on the system in megabytes (MB).
    /// </summary>
    public int TotalPhysicalMb { get; init; }

    /// <summary>
    /// Gets or sets the total amount of virtual memory available on the system in megabytes (MB).
    /// </summary>
    public int TotalVirtualMb { get; init; }

    /// <summary>
    /// Gets or sets the type of memory used in the system, such as DDR, DDR2, DDR3, or DDR4.
    /// </summary>
    public MemoryType Type { get; init; }

    /// <summary>
    /// Gets or sets the speed of the memory in megahertz (MHz).
    /// </summary>
    public int SpeedMHz { get; init; }
}