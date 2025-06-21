namespace Domain.Entities.System;

/// <summary>
/// Represents a GPU (Graphics Processing Unit) with its associated properties and specifications.
/// </summary>
public record struct Gpu(
    string Model,
    float MemoryGb,
    float DedicatedVideoRamGb,
    double PixelShader,
    double VertexShader
);