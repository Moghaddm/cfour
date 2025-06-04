using CFour.Enums.System;

namespace CFour.Entities.System;

/// <summary>
/// Represents the storage subsystem of a system, providing information about
/// the main drive, storage capacity, and performance characteristics.
/// </summary>
public sealed class Storage
{
    /// <summary>
    /// Gets or sets the type of the main drive in the system.
    /// </summary>
    /// <remarks>
    /// The main drive type is represented by the <c>MainDrive</c> enumeration,
    /// which provides options such as HDD and SSD.
    /// </remarks>
    public MainDrive MainDrive { get; set; }

    /// <summary>
    /// Gets or sets the total storage capacity of the system's main drive, expressed in bytes.
    /// </summary>
    public long TotalStorageSpaceBytes { get; set; }

    /// <summary>
    /// Gets or sets the amount of available storage space in bytes on the main drive.
    /// </summary>
    /// <remarks>
    /// This property represents the free storage capacity, measured in bytes,
    /// and indicates the remaining writable space on the drive.
    /// </remarks>
    public long FreeStorageSpaceBytes { get; set; }

    /// <summary>
    /// Gets or sets the read speed of the drive in megabytes per second (MBps).
    /// </summary>
    /// <remarks>
    /// This property represents the performance capability of the drive when reading data,
    /// indicating how quickly the drive can retrieve information.
    /// </remarks>
    public int DriveReadSpeedMBps { get; set; }

    /// <summary>
    /// Gets or sets the write speed of the drive in megabytes per second (MBps).
    /// </summary>
    /// <remarks>
    /// This property indicates the maximum sequential write performance of the drive,
    /// which can vary based on the drive type, workload, and system configuration.
    /// </remarks>
    public int DriveWriteSpeedMBps { get; set; }
}