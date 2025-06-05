using CFour.Constants;
using CFour.DTOs.Match;
using CFour.Entities.Game;
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
        var response = await aiClient.GetChatClient(AiConstants.ChatModel)
            .CompleteChatAsync(prompt, cancellationToken: cancellationToken);

        return default;
    }

    private static List<ChatMessage> GeneratePrompt()
    {
        List<ChatMessage> promptMessages = [];

        /*
         * SYSTEM PROMPTS
         * GAME SPECIFICATIONS
         * USER SYSTEM SPECIFICATION
         */

        var systemPrompts = "";
        promptMessages.Add(new SystemChatMessage(systemPrompts));

        return promptMessages;
    }
}