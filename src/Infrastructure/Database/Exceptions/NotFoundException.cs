namespace Infrastructure.Database.Exceptions;

/// <summary>
/// Represents an abstraction for exceptions thrown when a required entity or resource is not found.
/// </summary>
public abstract class NotFoundException : Exception
{
    protected NotFoundException(string message) : base(message)
    {
    }

    protected NotFoundException(string message, Exception? innerException) : base(message, innerException)
    {
    }
}

/// <summary>
/// Represents an exception that is thrown when a specific entity is not found in the context of a database operation.
/// </summary>
public sealed class EntityNotFoundException(string type, string id)
    : NotFoundException($"There is not any entity with provided type and id. [Type]=({type}), [ID]=({id}).");