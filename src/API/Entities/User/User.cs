using CFour.Base;
using CFour.Entities.System;

namespace CFour.Entities.User;

/// <summary>
/// Represents a user in the system.
/// This class is designed to encapsulate the essential
/// user information including personal details and metadata
/// regarding the user's account creation and modification.
/// </summary>
public sealed class User : BaseAuditedEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class with the provided property values.
    /// </summary>
    /// <param name="id">The unique identifier for the user.</param>
    /// <param name="concurrencyStamp">The concurrency stamp of the user entity.</param>
    /// <param name="firstName">The given name of the user.</param>
    /// <param name="lastName">The family or surname of the user.</param>
    /// <param name="email">The email address of the user.</param>
    /// <param name="phoneNumber">The phone number of the user.</param>
    /// <param name="avatarAttachmentId">The unique identifier for the user's avatar attachment.</param>
    /// <param name="systemSpecifications">The collection of system specifications associated with the user.</param>
    public User(
        string id,
        string concurrencyStamp,
        string firstName,
        string lastName,
        string email,
        string phoneNumber,
        long avatarAttachmentId,
        IList<SystemSpecification> systemSpecifications
    )
    {
        Id = id;
        ConcurrencyStamp = concurrencyStamp;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        AvatarAttachmentId = avatarAttachmentId;
        SystemSpecifications = systemSpecifications;
    }

    /// <summary>
    /// Gets or sets the first name of the user.
    /// This property represents the given name of the user
    /// and is a mandatory field for user identification purposes.
    /// </summary>
    public string FirstName { get; private set; }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// This property represents the user's family or surname
    /// and is required to identify the individual.
    /// </summary>
    public string LastName { get; private set; }

    /// <summary>
    /// Gets or sets the email address of the user.
    /// This property represents the user's primary email contact
    /// and is a required field for communication purposes and account identification.
    /// </summary>
    public string Email { get; private set; }

    /// <summary>
    /// Gets or sets the phone number associated with the user.
    /// This property identifies the user's contact number and
    /// can be used for communication or identification purposes.
    /// </summary>
    public string PhoneNumber { get; private set; }

    /// <summary>
    /// Gets or sets the unique identifier for the user's avatar attachment.
    /// This property is used to associate the user with an externally stored avatar image.
    /// </summary>
    public long AvatarAttachmentId { get; private set; }

    /// <summary>
    /// Gets or sets the collection of system specifications associated with the user.
    /// This property provides detailed information about the user's hardware and software components,
    /// including processor, memory, storage, GPU, operating system, and display details.
    /// </summary>
    public IList<SystemSpecification> SystemSpecifications { get; private set; }
}