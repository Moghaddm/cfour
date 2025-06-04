namespace CFour.Enums.System;

/// <summary>
/// Represents the types of memory modules that can be used in a system.
/// </summary>
public enum MemoryType : byte
{
    SdrSDram = 1,
    Ddr = 2,
    Ddr2 = 4,
    Ddr3 = 8,
    Ddr4 = 16,
    Ddr5 = 32,
    RDram = 64,
    SRam = 128
}