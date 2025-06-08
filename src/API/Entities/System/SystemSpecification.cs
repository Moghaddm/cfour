namespace CFour.Entities.System;

/// <summary>
/// Represents detailed information about the system's hardware and software components.
/// Provides access to information such as processor, memory, storage, GPU, operating system, and display details.
/// </summary>
public record struct SystemSpecification
{
    /// <summary>
    /// Represents the specifications of a system, including its hardware and software components.
    /// </summary>
    public SystemSpecification(
        Guid unique,
        Processor processor,
        Memory memory,
        Storage storage,
        Gpu gpu,
        OperationSystem operationSystem,
        Display display,
        bool isLaptop
    )
    {
        Unique = unique;
        Processor = processor;
        Memory = memory;
        Storage = storage;
        Gpu = gpu;
        OperationSystem = operationSystem;
        Display = display;
        IsLaptop = isLaptop;
    }

    /// <summary>
    /// Gets or sets the globally unique identifier (GUID) for identifying the system's specification instance.
    /// This identifier ensures the uniqueness of each system specification object within a given context.
    /// </summary>
    //[BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Unique { get; init; }

    /// <summary>
    /// Gets or sets the information about the system's central processing unit (CPU).
    /// This includes details such as the CPU's name, core and thread count, architecture,
    /// base clock speed, and maximum clock speed.
    /// </summary>
    public Processor Processor { get; init; }

    /// <summary>
    /// Gets or sets the memory details of the system.
    /// Contains information about physical and virtual memory, including their total and available capacities,
    /// the type and speed of the memory.
    /// </summary>
    public Memory Memory { get; init; }

    /// <summary>
    /// Represents the storage subsystem of a system, providing details about the
    /// main storage drive, total and free storage capacity, as well as read and
    /// write performance characteristics.
    /// </summary>
    public Storage Storage { get; init; }

    /// <summary>
    /// Gets or sets the information about the system's graphics processing unit (GPU).
    /// This includes details such as the GPU model, manufacturer, memory size, clock speeds,
    /// driver version, and support for features like ray tracing.
    /// </summary>
    public Gpu Gpu { get; init; }

    /// <summary>
    /// Gets or sets the information about the operating system installed on the system.
    /// This includes details such as the operating system type, version, build number, and architecture.
    /// </summary>
    public OperationSystem OperationSystem { get; init; }

    /// <summary>
    /// Gets or sets the details about the system's display configuration and properties.
    /// This includes information such as resolution, technology type, and color depth.
    /// </summary>
    public Display Display { get; init; }

    /// <summary>
    /// Indicates whether the system is a laptop.
    /// This property returns true if the device is identified as a laptop,
    /// typically determined by factors such as form factor, built-in display, and integrated battery.
    /// </summary>
    public bool IsLaptop { get; init; }
}