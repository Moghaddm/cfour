namespace CFour.Entities.System;

/// <summary>
/// Represents a GPU (Graphics Processing Unit) with its associated properties and specifications.
/// </summary>
public sealed class Gpu
{
    /// <summary>
    /// Gets or sets the model of the GPU.
    /// </summary>
    public string Model { get; set; } = null!;

    /// <summary>
    /// Gets or sets the manufacturer of the GPU.
    /// </summary>
    public string Manufacturer { get; set; } = null!;

    /// <summary>
    /// Gets or sets the memory capacity of the GPU in gigabytes (GB).
    /// </summary>
    public double MemoryGb { get; set; }

    /// <summary>
    /// Gets or sets the base clock speed of the GPU in megahertz (MHz).
    /// </summary>
    public double BaseClockSpeedMHz { get; set; }

    /// <summary>
    /// Gets or sets the boost clock speed of the GPU in megahertz (MHz).
    /// </summary>
    public double BoostClockSpeedMHz { get; set; }

    /// <summary>
    /// Gets or sets the version of the GPU driver.
    /// </summary>
    public string DriverVersion { get; set; } = null!;

    /// <summary>
    /// Gets or sets a value indicating whether the GPU supports ray tracing technology.
    /// </summary>
    public bool SupportsRayTracing { get; set; }
}