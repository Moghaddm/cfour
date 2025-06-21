using Domain.Entities.System;

namespace Application.DTOs.Game;

public record struct CreateGameRequirementDto(
    IList<Processor> Processors,
    Memory Memory,
    Storage Storage,
    IList<Gpu> Gpus,
    OperationSystem OperationSystem,
    Display Display,
    string? SoundCard,
    bool IsLaptop
);