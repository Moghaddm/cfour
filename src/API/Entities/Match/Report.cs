using CFour.Enums.Match;

namespace CFour.Entities.Match;

/// <summary>
/// Represents a compatibility report generated for evaluating the playability
/// and performance of a game or application. This struct provides information
/// on whether the system meets the required specifications and offers details
/// on estimated performance, bottlenecks, and recommendations.
/// </summary>
public struct Report(
    string Description,
    bool IsPlayable,
    Verdict Verdict,
    RecommendationPreset RecommendedPreset,
    Resolution RecommendedResolution,
    int? EstimatedAvgFps,
    int? EstimatedMinFps,
    int? EstimatedMaxFps,
    bool CpuMeetsMinimum,
    bool GpuMeetsMinimum,
    bool RamMeetsMinimum,
    bool VRamMeetsMinimum,
    bool StorageMeetsMinimum,
    bool OsMeetsMinimum,
    IList<Bottleneck> Bottlenecks
);