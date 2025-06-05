using CFour.Enums.Match;

namespace CFour.Entities.Match;

/// <summary>
/// Represents a bottleneck component in a system and provides a description of the bottleneck condition.
/// </summary>
/// <remarks>
/// This record encapsulates a specific component that may act as a bottleneck in a system and an explanation
/// describing why it is considered a bottleneck.
/// </remarks>
public sealed record Bottleneck(
    BottleneckComponent Component,
    string Explanation,
    string ImproveGuidance
);