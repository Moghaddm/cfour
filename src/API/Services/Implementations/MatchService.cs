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
    public async Task<Guid> MatchAsync(MatchInDto inDto, CancellationToken cancellationToken)
    {
        var game = await gameRepository.GetToMatchByIdAsync(inDto.GameId, cancellationToken);
        var systemSpecification =
            await userRepository.LoadUserMatchingSpecAsync(inDto.UserId, inDto.SystemSpecificationUnique,
                cancellationToken);

        var prompt = GeneratePrompt(systemSpecification, game);

        await aiClient.GetChatClient(AiConstants.ChatAiModel)
            .CompleteChatAsync(prompt, cancellationToken: cancellationToken);

        var report = new Report();
        var match = new Match(inDto.UserId, inDto.SystemSpecificationUnique, inDto.GameId, report);

        await matchRepository.AddAsync(match, cancellationToken);

        return default;
    }

    private static List<ChatMessage> GeneratePrompt(SystemSpecification systemSpecification, Game game)
    {
        List<ChatMessage> promptMessages =
        [
            new SystemChatMessage(AiConstants.MatchSystemPrompts),
            new UserChatMessage(systemSpecification.ToPrompts(["User's machine specification is described below:"])),
            new UserChatMessage(
                $"The game for matching and compatibility is \"{game.Title}\" described as \"{game.Description}\""
            ),
            new UserChatMessage(
                game.MinimumRequirement.ToPrompts(["Below are the minimum requirements for the game:"])
            ),
            new UserChatMessage(
                game.RecommendedRequirement.ToPrompts(["Below are the recommended requirements for the game:"])
            )
        ];

        return promptMessages;
    }
}