namespace CFour.Entities.System;

/// <summary>
/// Represents a central processing unit (CPU) of a system with details about its specifications
/// such as the name, core count, thread count, architecture, and clock speeds.
/// </summary>
public sealed class Processor
{
    /// <summary>
    /// Represents the name or model identifier of the processor.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Represents the number of physical cores available in the processor.
    /// </summary>
    public int Cores { get; set; }

    /// <summary>
    /// Gets or sets the number of threads available in the processor.
    /// </summary>
    public int Threads { get; set; }

    /// <summary>
    /// Represents the micro-architecture or design type of the processor.
    /// </summary>
    public string Architecture { get; set; } = null!;

    /// <summary>
    /// Indicates the base clock speed of the processor in gigahertz (GHz).
    /// </summary>
    public double BaseClockSpeedGHz { get; set; }

    /// <summary>
    /// Represents the maximum clock speed of the processor in gigahertz (GHz).
    /// </summary>
    public double MaxClockSpeedGHz { get; set; }
}