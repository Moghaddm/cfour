namespace Common.Enums.Match;

/// <summary>
/// Identifies components that may act as bottlenecks in a system.
/// </summary>
/// <remarks>
/// This enumeration is used to categorize system components that could become performance bottlenecks.
/// Each value represents a specific type of hardware or software component.
/// </remarks>
public enum BottleneckComponent
{
    Cpu = 1,
    Gpu = 2,
    Ram = 4,
    Storage = 8,
    Os = 16
}