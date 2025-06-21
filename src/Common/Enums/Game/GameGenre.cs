namespace Common.Enums.Game;

/// <summary>
/// Represents various genres for games.
/// </summary>
[Flags]
public enum GameGenre
{
    None = 0,
    Action = 1,
    Adventure = 2,
    RolePlayingGame = 4,
    Simulation = 8,
    RealTimeStrategy = 16,
    Sports = 32,
    Racing = 64,
    Logic = 128,
    PartyGame = 256,
    Survival = 512,
    Sandbox = 1024,
    OpenWorld = 2048,
    MassivelyMultiplayerOnline = 4096,
    MultiplayerOnlineBattleArena = 8192,
    Casual = 16384,
    Idle = 32768,
    Experimental = 65536,
    Educational = 131072,
    BattleRoyale = 262144,
    Horror = SurvivalHorror | PsychologicalHorror,
    SurvivalHorror = 524288,
    PsychologicalHorror = 1048576
}