namespace CFour.Entities.System;

/// <summary>
/// Represents a central processing unit (CPU) of a system with details about its specifications
/// such as the name, core count, thread count, architecture, and clock speeds.
/// </summary>
public struct Processor
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Processor"/> class with the specified properties.
    /// </summary>
    /// <param name="name">The name or model identifier of the processor.</param>
    /// <param name="cores">The number of physical cores in the processor.</param>
    /// <param name="threads">The number of threads in the processor.</param>
    /// <param name="architecture">The architecture type of the processor.</param>
    /// <param name="baseClockSpeedGHz">The base clock speed of the processor in GHz.</param>
    /// <param name="maxClockSpeedGHz">The maximum clock speed of the processor in GHz.</param>
    public Processor(string name, int cores, int threads, string architecture, double baseClockSpeedGHz,
        double maxClockSpeedGHz)
    {
        Name = name;
        Cores = cores;
        Threads = threads;
        Architecture = architecture;
        BaseClockSpeedGHz = baseClockSpeedGHz;
        MaxClockSpeedGHz = maxClockSpeedGHz;
    }

    /// <summary>
    /// Represents the name or model identifier of the processor.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Represents the number of physical cores available in the processor.
    /// </summary>
    public int Cores { get; init; }

    /// <summary>
    /// Gets or inits the number of threads available in the processor.
    /// </summary>
    public int Threads { get; init; }

    /// <summary>
    /// Represents the micro-architecture or design type of the processor.
    /// </summary>
    public string Architecture { get; init; }

    /// <summary>
    /// Indicates the base clock speed of the processor in gigahertz (GHz).
    /// </summary>
    public double BaseClockSpeedGHz { get; init; }

    /// <summary>
    /// Represents the maximum clock speed of the processor in gigahertz (GHz).
    /// </summary>
    public double MaxClockSpeedGHz { get; init; }
}