namespace Application.DTOs.Compare;

public record CompareInDto(
    string GameId,
    string UserId,
    string UserMachineUnique
);