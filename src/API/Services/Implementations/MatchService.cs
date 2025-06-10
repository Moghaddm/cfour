using System.Text.Json;
using CFour.Constants;
using CFour.DTOs.Match;
using CFour.Entities.Game;
using CFour.Entities.Match;
using CFour.Entities.System;
using CFour.Entities.User;
using CFour.Helpers.Match;
using CFour.Services.Interfaces;
using OpenAI;
using OpenAI.Chat;

namespace CFour.Services.Implementations;

/// <inheritdoc cref="IMatchService"/>
public sealed class MatchService(
    IGameRepository gameRepository,
    IUserRepository userRepository,
    OpenAIClient aiClient,
    IMatchRepository matchRepository
) : IMatchService
{
    /// <inheritdoc cref="IMatchService.MatchAsync"/>
    public async Task<string> MatchAsync(MatchInDto inDto, CancellationToken cancellationToken)
    {
        var game = await gameRepository.GetToMatchByIdAsync(inDto.GameId, cancellationToken);
        var systemSpecification =
            await userRepository.LoadUserMatchingSpecAsync(inDto.UserId, inDto.SystemSpecificationUnique,
                cancellationToken);

        var prompt = GeneratePrompt(systemSpecification, game);

        var response = await aiClient.GetChatClient(AiConstants.ChatAiModel)
            .CompleteChatAsync(prompt, cancellationToken: cancellationToken);

        var reportMessage = response.Value.Content[0].Text;

        var report = JsonSerializer.Deserialize<Report>(reportMessage);
        var match = new Match(inDto.UserId, inDto.SystemSpecificationUnique, inDto.GameId, report);

        await matchRepository.AddAsync(match, cancellationToken);

        return match.Id;
    }

    private static List<ChatMessage> GeneratePrompt(SystemSpecification systemSpecification, Game game)
    {
        var userSystemSpecification =
            new AssistantChatMessage(
                systemSpecification.ToPrompts(["User's machine specification is described below:"]));

        var gameContent = new AssistantChatMessage(
            $"The game for matching and compatibility is \"{game.Title}\" described as \"{game.Description}\""
        );

        var minimumRequirements = new AssistantChatMessage(
            game.MinimumRequirement.ToPrompts(["Below are the minimum requirements for the game:"])
        );

        var recommendedRequirements = new AssistantChatMessage(
            game.RecommendedRequirement.ToPrompts(["Below are the recommended requirements for the game:"])
        );

        List<ChatMessage> promptMessages =
        [
            new SystemChatMessage(AiConstants.BaseContextPrompt),
            new SystemChatMessage(AiConstants.MatchSystemPersonaPrompts),
            userSystemSpecification,
            gameContent,
            minimumRequirements,
            recommendedRequirements
        ];

        return promptMessages;
    }
}