using CFour.Constants;
using CFour.DTOs.Match;
using CFour.Entities.Game;
using CFour.Entities.System;
using CFour.Entities.User;
using CFour.Services.Interfaces;
using OpenAI;
using OpenAI.Chat;

namespace CFour.Services.Implementations;

/// <inheritdoc cref="IMatchService"/>
public sealed class MatchService(IGameRepository gameRepository, IUserRepository userRepository, OpenAIClient aiClient)
    : IMatchService
{
    /// <inheritdoc cref="IMatchService.MatchAsync"/>
    public async Task<Guid> MatchAsync(MatchInDto inDto, CancellationToken cancellationToken)
    {
        var game = await gameRepository.GetAsync(inDto.GameId, cancellationToken);
        var systemSpecification = await userRepository.GetAsync(inDto.UserId, cancellationToken);
        //systemSpecification.SystemSpecifications.Where(spc => spc.Unique.ToString() == inDto.SystemSpecificationUnique);

        var prompt = GeneratePrompt();
        var response = await aiClient.GetChatClient(AiConstants.ChatAiModel)
            .CompleteChatAsync(prompt, cancellationToken: cancellationToken);

        return default;
    }

    private static List<ChatMessage> GeneratePrompt(SystemSpecification systemSpecification, Game game)
    {
        List<ChatMessage> promptMessages = [new SystemChatMessage(AiConstants.MatchSystemPrompts)];

        // USER MACHINE INFORMATION
        var processor = systemSpecification.Processor;
        var memory = systemSpecification.Memory;
        var storage = systemSpecification.Storage;
        var gpu = systemSpecification.Gpu;
        var operationSystem = systemSpecification.OperationSystem;
        var display = systemSpecification.Display;
        List<string> systemSpecificationPrompts =
        [
            "User's machine specifications are described below:",
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
            $"- Refresh Rate: {display.MonitorRefreshRateHz} Hz",
            $"- Machine Type: {(systemSpecification.IsLaptop ? "Laptop" : "Desktop")}"
        ];
        promptMessages.Add(new UserChatMessage(string.Join("\n", systemSpecificationPrompts)));

        // GAME REQUIREMENTS
        List<string> gameRequirements =
        [
        ];
        promptMessages.Add(new UserChatMessage(string.Join("\n", gameRequirements)));

        return promptMessages;
    }
}