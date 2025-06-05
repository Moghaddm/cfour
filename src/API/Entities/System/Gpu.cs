namespace CFour.Entities.System;

/// <summary>
/// Represents a GPU (Graphics Processing Unit) with its associated properties and specifications.
/// </summary>
public record Gpu
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Gpu"/> struct with specified properties.
    /// </summary>
    /// <param name="model">The model of the GPU.</param>
    /// <param name="manufacturer">The manufacturer of the GPU.</param>
    /// <param name="memoryGb">The memory capacity of the GPU in gigabytes (GB).</param>
    /// <param name="baseClockSpeedMHz">The base clock speed of the GPU in megahertz (MHz).</param>
    /// <param name="boostClockSpeedMHz">The boost clock speed of the GPU in megahertz (MHz).</param>
    /// <param name="driverVersion">The version of the GPU driver.</param>
    /// <param name="supportsRayTracing">A value indicating whether the GPU supports ray tracing technology.</param>
    public Gpu(
        string model,
        string manufacturer,
        double memoryGb,
        double baseClockSpeedMHz,
        double boostClockSpeedMHz,
        string driverVersion,
        bool supportsRayTracing)
    {
        Model = model;
        Manufacturer = manufacturer;
        MemoryGb = memoryGb;
        BaseClockSpeedMHz = baseClockSpeedMHz;
        BoostClockSpeedMHz = boostClockSpeedMHz;
        DriverVersion = driverVersion;
        SupportsRayTracing = supportsRayTracing;
    }

    /// <summary>
    /// Gets or sets the model of the GPU.
    /// </summary>
    public string Model { get; init; } = null!;

    /// <summary>
    /// Gets or sets the manufacturer of the GPU.
    /// </summary>
    public string Manufacturer { get; init; } = null!;

    /// <summary>
    /// Gets or sets the memory capacity of the GPU in gigabytes (GB).
    /// </summary>
    public double MemoryGb { get; init; }

    /// <summary>
    /// Gets or sets the base clock speed of the GPU in megahertz (MHz).
    /// </summary>
    public double BaseClockSpeedMHz { get; init; }

    /// <summary>
    /// Gets or sets the boost clock speed of the GPU in megahertz (MHz).
    /// </summary>
    public double BoostClockSpeedMHz { get; init; }

    /// <summary>
    /// Gets or sets the version of the GPU driver.
    /// </summary>
    public string DriverVersion { get; init; } = null!;

    /// <summary>
    /// Gets or sets a value indicating whether the GPU supports ray tracing technology.
    /// </summary>
    public bool SupportsRayTracing { get; init; }
}