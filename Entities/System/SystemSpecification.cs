namespace CFour.Entities.System;

/// <summary>
/// Represents detailed information about the system's hardware and software components.
/// Provides access to information such as processor, memory, storage, GPU, operating system, and display details.
/// </summary>
public sealed class SystemSpecification
{
    /// <summary>
    /// Gets or sets the information about the system's central processing unit (CPU).
    /// This includes details such as the CPU's name, core and thread count, architecture,
    /// base clock speed, and maximum clock speed.
    /// </summary>
    public Processor Processor { get; set; } = null!;

    /// <summary>
    /// Gets or sets the memory details of the system.
    /// Contains information about physical and virtual memory, including their total and available capacities,
    /// the type and speed of the memory.
    /// </summary>
    public Memory Memory { get; set; } = null!;

    /// <summary>
    /// Represents the storage subsystem of a system, providing details about the
    /// main storage drive, total and free storage capacity, as well as read and
    /// write performance characteristics.
    /// </summary>
    public Storage Storage { get; set; } = null!;

    /// <summary>
    /// Gets or sets the information about the system's graphics processing unit (GPU).
    /// This includes details such as the GPU model, manufacturer, memory size, clock speeds,
    /// driver version, and support for features like ray tracing.
    /// </summary>
    public Gpu Gpu { get; set; } = null!;

    /// <summary>
    /// Gets or sets the information about the operating system installed on the system.
    /// This includes details such as the operating system type, version, build number, and architecture.
    /// </summary>
    public OperationSystem OperationSystem { get; set; } = null!;

    /// <summary>
    /// Gets or sets the details about the system's display configuration and properties.
    /// This includes information such as resolution, technology type, and color depth.
    /// </summary>
    public Display Display { get; set; } = null!;
}