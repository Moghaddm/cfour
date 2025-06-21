namespace Common.Enums.Match;

/// <summary>
/// Represents the outcome or status of a match regarding its playability and performance.
/// </summary>
public enum Verdict
{
    Playable = 1,
    Smooth = 2,
    Laggy = 4,
    NotPlayable = 8
}