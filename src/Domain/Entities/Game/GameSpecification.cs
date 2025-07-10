using Domain.Entities.Game.Specification;
using OperatingSystem = Domain.Entities.Game.Specification.OperatingSystem;

namespace Domain.Entities.Game;

/// <summary>
/// Represents detailed information about the system's hardware and software components.
/// Provides access to information such as processor, memory, storage, GPU, operating system, and display details.
/// </summary>
public record struct GameSpecification
{
    /// <summary>
    /// Represents the specifications of a system, including its hardware and software components.
    /// </summary>
    public GameSpecification(
        Guid unique,
        IList<Processor> processors,
        Memory memory,
        Storage storage,
        IList<Gpu> gpus,
        OperatingSystem operatingSystem,
        Display display,
        string? soundCard
    )
    {
        Unique = unique;
        Processors = processors;
        Memory = memory;
        Storage = storage;
        Gpus = gpus;
        OperatingSystem = operatingSystem;
        Display = display;
        SoundCard = soundCard;
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
    public IList<Processor> Processors { get; init; }

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
    public IList<Gpu> Gpus { get; init; }

    /// <summary>
    /// Gets or sets the information about the operating system installed on the system.
    /// This includes details such as the operating system type, version, build number, and architecture.
    /// </summary>
    public OperatingSystem OperatingSystem { get; init; }

    /// <summary>
    /// Gets or sets the details about the system's display configuration and properties.
    /// This includes information such as resolution, technology type, and color depth.
    /// </summary>
    public Display Display { get; init; }

    /// <summary>
    /// Gets or sets the identifier or name of the sound card in the system.
    /// This property provides details about the audio hardware installed, which can include
    /// manufacturer and model information.
    /// </summary>
    public string? SoundCard { get; init; }
}