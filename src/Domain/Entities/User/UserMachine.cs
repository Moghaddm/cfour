using Domain.Entities.Game.Specification;
using OperatingSystem = Domain.Entities.Game.Specification.OperatingSystem;

namespace Domain.Entities.User;

public record UserMachine(
    string Unique,
    Processor Processor,
    Memory Memory,
    Storage Storage,
    Gpu Gpu,
    OperatingSystem OperatingSystem,
    Display Display,
    string? SoundCard,
    bool IsLaptop
);