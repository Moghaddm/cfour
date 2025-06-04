namespace CFour.Enums.Game;

/// <summary>
/// Represents various gaming platforms where a game can be played.
/// </summary>
public enum GamePlatform : byte
{
    Pc = 1,
    Ps5 = 2,
    Ps4 = 4,
    XboxSeriesX = 8,
    XboxOne = 16,
    NintendoSwitch = 32,
    Mobile = 64
}