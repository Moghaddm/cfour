namespace Domain.Entities.System;

/// <summary>
/// Represents a central processing unit (CPU) of a system with details about its specifications
/// such as the name, core count, thread count, architecture, and clock speeds.
/// </summary>
public record struct Processor(
    string Name,
    int Cores,
    int Threads,
    double BaseClockSpeedGHz,
    double TurboClockGHz
);