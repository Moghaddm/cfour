using CFour.Enums.System;

namespace CFour.Entities.System;

/// <summary>
/// Represents the storage subsystem of a system, providing information about
/// the main drive, storage capacity, and performance characteristics.
/// </summary>
public struct Storage
{
    /// <summary>
    /// Represents storage-related information such as type of the main drive,
    /// available storage space, and drive speeds.
    /// </summary>
    public Storage(MainDrive mainDrive, long totalStorageSpaceBytes, long freeStorageSpaceBytes)
    {
        MainDrive = mainDrive;
        TotalStorageSpaceBytes = totalStorageSpaceBytes;
        FreeStorageSpaceBytes = freeStorageSpaceBytes;
    }

    /// <summary>
    /// Gets or sets the type of the main drive in the system.
    /// </summary>
    /// <remarks>
    /// The main drive type is represented by the <c>MainDrive</c> enumeration,
    /// which provides options such as HDD and SSD.
    /// </remarks>
    public MainDrive MainDrive { get; init; }

    /// <summary>
    /// Gets or sets the total storage capacity of the system's main drive, expressed in bytes.
    /// </summary>
    public long TotalStorageSpaceBytes { get; init; }

    /// <summary>
    /// Gets or sets the amount of available storage space in bytes on the main drive.
    /// </summary>
    /// <remarks>
    /// This property represents the free storage capacity, measured in bytes,
    /// and indicates the remaining writable space on the drive.
    /// </remarks>
    public long FreeStorageSpaceBytes { get; init; }
}