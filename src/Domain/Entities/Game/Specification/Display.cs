namespace Domain.Entities.Game.Specification;

/// <summary>
/// Represents the display configuration and properties of a system.
/// </summary>
public record struct Display(
    int Width,
    int Height,
    int MonitorRefreshRateHz
);