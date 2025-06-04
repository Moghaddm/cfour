using CFour.Base;

namespace CFour.Entities.Attachment;

/// <summary>
/// Represents a sealed entity that stores information about a file attachment.
/// </summary>
/// <remarks>
/// Inherits from <see cref="BaseRemovableEntity"/> to provide properties and functionality related to the entity's lifecycle,
/// such as tracking removal and modification.
/// The entity includes details about the file's name, location, format, and content type.
/// </remarks>
public sealed class Attachment : BaseRemovableEntity
{
    /// <summary>
    /// Gets or sets the name of the file associated with the attachment.
    /// </summary>
    /// <remarks>
    /// This property represents the name of the file without including its path.
    /// It is used to identify the file linked to the attachment entity and is expected
    /// to include the filename without the extension.
    /// </remarks>
    public string FileName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the location of the file associated with the attachment.
    /// </summary>
    /// <remarks>
    /// This property represents the file's address or path where it is stored or accessed.
    /// It is utilized to determine the physical or virtual location of the file in the system.
    /// </remarks>
    public string Address { get; set; } = null!;

    /// <summary>
    /// Gets or sets the file extension associated with the attachment.
    /// </summary>
    /// <remarks>
    /// This property represents the extension of the file, such as "txt", "jpg", "pdf", etc.
    /// It is used to define the format or type of the file and typically includes the leading period.
    /// </remarks>
    public string Extension { get; set; } = null!;

    /// <summary>
    /// Gets or sets the MIME type of the content associated with the attachment.
    /// </summary>
    /// <remarks>
    /// This property represents the media type that indicates the format of the file's content.
    /// It is commonly used to specify file types in Internet protocols and includes types such as "image/png", "application/pdf", etc.
    /// </remarks>
    public string ContentType { get; set; } = null!;

    /// <summary>
    /// Gets or sets a value indicating whether the attachment is marked as permanent.
    /// </summary>
    /// <remarks>
    /// This property determines if the attachment is intended to be retained indefinitely and is not subject
    /// to typical lifecycle operations such as removal or archiving.
    /// </remarks>
    public bool IsPermanent { get; set; }
}