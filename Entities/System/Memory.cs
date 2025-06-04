using CFour.Enums.System;

namespace CFour.Entities.System;

/// <summary>
/// Represents the memory information of a system, including physical and virtual memory details.
/// </summary>
public sealed class Memory
{
    /// <summary>
    /// Gets or sets the total amount of physical memory available on the system in megabytes (MB).
    /// </summary>
    public int TotalPhysicalMb { get; set; }

    /// <summary>
    /// Gets or sets the amount of available physical memory in megabytes.
    /// </summary>
    public int AvailablePhysicalMb { get; set; }

    /// <summary>
    /// Gets or sets the total amount of virtual memory available on the system in megabytes (MB).
    /// </summary>
    public int TotalVirtualMb { get; set; }

    /// <summary>
    /// Gets or sets the amount of virtual memory currently available on the system in megabytes (MB).
    /// </summary>
    public int AvailableVirtualMb { get; set; }

    /// <summary>
    /// Gets or sets the type of memory used in the system, such as DDR, DDR2, DDR3, or DDR4.
    /// </summary>
    public MemoryType Type { get; set; }

    /// <summary>
    /// Gets or sets the speed of the memory in megahertz (MHz).
    /// </summary>
    public int SpeedMHz { get; set; }
}