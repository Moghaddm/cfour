using System.Text.Json;
using Application.DTOs.Compare;
using Application.Services.Interfaces;
using Common.Constants;
using Domain.Entities.Compare;
using Domain.Entities.Game;
using Domain.Entities.User;
using Domain.Repositories;
using OpenAI;
using OpenAI.Chat;

namespace Application.Services.Implementations;

/// <inheritdoc cref="ICompareService"/>
public sealed class CompareService(
    IGameRepository gameRepository,
    IUserRepository userRepository,
    OpenAIClient aiClient,
    ICompareRepository compareRepository
) : ICompareService
{
    /// <inheritdoc cref="ICompareService.CompareAsync"/>
    public async Task<string> CompareAsync(CompareInDto inDto, CancellationToken cancellationToken)
    {
        var game = await gameRepository.GetCompareDataByIdAsync(inDto.GameId, cancellationToken);

        var userMachine = await userRepository.GetUserMachineByUniqueAsync(
            inDto.UserId,
            inDto.UserMachineUnique,
            cancellationToken
        );

        List<ChatMessage> prompt =
        [
            new SystemChatMessage(AiConstants.BaseContextPrompt),
            new SystemChatMessage(AiConstants.MatchSystemPersonaPrompts),
            new AssistantChatMessage(PromptingByUserMachine(userMachine)),
            new AssistantChatMessage(PromptingGameInfo(game)),
            new AssistantChatMessage(PromptingByGameSpec(game.MinimumRequirement, true)),
            new AssistantChatMessage(PromptingByGameSpec(game.RecommendedRequirement, false))
        ];

        var response = await aiClient
            .GetChatClient(AiConstants.ChatAiModel)
            .CompleteChatAsync(prompt, cancellationToken: cancellationToken);

        var reportMessage = response.Value.Content[0].Text;

        var report = JsonSerializer.Deserialize<Report>(reportMessage);
        var match = new Compare(
            inDto.UserId,
            inDto.UserMachineUnique,
            inDto.GameId,
            report
        );

        await compareRepository.AddAsync(match, cancellationToken);

        return match.Id;
    }

    private static string PromptingGameInfo(Game game)
    {
        return $"The game for matching and compatibility is \"{game.Title}\" described as \"{game.Description}\".";
    }

    private static string PromptingByUserMachine(UserMachine userMachine)
    {
        const string contextText = "User's machine specification is described below:";

        var processor = userMachine.Processor;
        var memory = userMachine.Memory;
        var storage = userMachine.Storage;
        var gpu = userMachine.Gpu;
        var operationSystem = userMachine.OperatingSystem;
        var display = userMachine.Display;

        List<string> prompts =
        [
            contextText,
            "Processor:",
            $"- Name: {processor.Name}",
            $"- Total Cores: {processor.Cores}",
            $"- Threads: {processor.Threads}",
            $"- Base Clock Speed: {processor.BaseClockSpeedGHz} GHz",
            $"- Turbo Clock Speed: {processor.TurboClockGHz} GHz",
            "Memory:",
            $"- RAM: {memory.RamTotalMb} MB",
            $"- GRAM: {memory.VRamTotalMb} MB",
            "Storage:",
            $"- Available Space: {storage.AvailableMb} MB",
            $"- Type: {storage.Type}",
            "GPU:",
            $"- Model: {gpu.Model}",
            $"- Memory: {gpu.MemoryGb} GB",
            "Operating System:",
            $"- Type: {operationSystem.Type}",
            $"- Version: {operationSystem.Version}",
            $"- Architecture: {operationSystem.Architecture}",
            "Display:",
            $"- Resolution: {display.Width}x{display.Height}",
            $"- Refresh Rate: {display.MonitorRefreshRateHz} Hz"
        ];

        return string.Join('\n', prompts);
    }

    private static string PromptingByGameSpec(GameSpecification gameSpecification, bool isMinimum)
    {
        var context = isMinimum
            ? "Below are the minimum requirements for the game:"
            : "Below are the recommended requirements for the game:";

        var processor = gameSpecification.Processors.First() with
        {
            Name = $"{gameSpecification.Processors[0].Name} / {gameSpecification.Processors[1].Name}"
        };
        var gpu = gameSpecification.Gpus.First() with
        {
            Model = $"{gameSpecification.Gpus[0].Model} / {gameSpecification.Gpus[1].Model}"
        };

        var memory = gameSpecification.Memory;
        var storage = gameSpecification.Storage;
        var operationSystem = gameSpecification.OperatingSystem;
        var display = gameSpecification.Display;

        List<string> prompts =
        [
            context,
            "Processor:",
            $"- Name: {processor.Name}",
            $"- Total Cores: {processor.Cores}",
            $"- Threads: {processor.Threads}",
            $"- Base Clock Speed: {processor.BaseClockSpeedGHz} GHz",
            $"- Turbo Clock Speed: {processor.TurboClockGHz} GHz",
            "Memory:",
            $"- RAM: {memory.RamTotalMb} MB",
            $"- GRAM: {memory.VRamTotalMb} MB",
            "Storage:",
            $"- Available Space: {storage.AvailableMb} MB",
            $"- Type: {storage.Type}",
            "GPU:",
            $"- Model: {gpu.Model}",
            $"- Memory: {gpu.MemoryGb} GB",
            "Operating System:",
            $"- Type: {operationSystem.Type}",
            $"- Version: {operationSystem.Version}",
            $"- Architecture: {operationSystem.Architecture}",
            "Display:",
            $"- Resolution: {display.Width}x{display.Height}",
            $"- Refresh Rate: {display.MonitorRefreshRateHz} Hz"
        ];

        return string.Join('\n', prompts);
    }
}