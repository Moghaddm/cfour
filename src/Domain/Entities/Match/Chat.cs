namespace Domain.Entities.Match;

/// <summary>
/// Represents a chat entry containing the user's input, system-generated response, and the timestamp of the interaction.
/// </summary>
/// <remarks>
/// This class is a sealed class and serves as a model for recording chat data. It encapsulates the user's query, the associated response,
/// and the time when the question was asked.
/// </remarks>
public sealed record Chat(
    string Input,
    string Response,
    DateTime AskedAt
);