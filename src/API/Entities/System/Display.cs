using CFour.Enums.System;

namespace CFour.Entities.System;

/// <summary>
/// Represents the display configuration and properties of a system.
/// </summary>
public struct Display
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Display"/> struct with specified properties.
    /// </summary>
    /// <param name="resolutionHeight">The vertical resolution of the display in pixels.</param>
    /// <param name="resolutionWidth">The width of the display resolution in pixels.</param>
    /// <param name="technologyType">The type of display technology used.</param>
    /// <param name="colorDepthByBit">The color depth of the display in bits.</param>
    public Display(ushort resolutionHeight, ushort resolutionWidth, DisplayTechnologyType technologyType,
        int colorDepthByBit)
    {
        ResolutionHeight = resolutionHeight;
        ResolutionWidth = resolutionWidth;
        TechnologyType = technologyType;
        ColorDepthByBit = colorDepthByBit;
    }

    /// <summary>
    /// Gets or sets the vertical resolution of the display in pixels.
    /// </summary>
    /// <remarks>
    /// ResolutionHeight refers to the number of pixels that make up the height of the display
    /// in a vertical dimension. This value, combined with ResolutionWidth, defines the total
    /// display resolution, such as 1920x1080 or 1280x720.
    /// </remarks>
    public ushort ResolutionHeight { get; init; }

    /// <summary>
    /// Gets or sets the width of the display resolution in pixels.
    /// </summary>
    /// <remarks>
    /// ResolutionWidth defines the number of horizontal pixels displayed by the screen.
    /// It is an essential parameter for determining the clarity and detail of the visual output.
    /// </remarks>
    public ushort ResolutionWidth { get; init; }

    /// <summary>
    /// Gets or sets the type of display technology used by the display.
    /// </summary>
    /// <remarks>
    /// TechnologyType defines the specific technology utilized in the display, such as LCD, LED, or OLED.
    /// The value is represented by the DisplayTechnologyType enumeration, which categorizes supported display technologies.
    /// </remarks>
    public DisplayTechnologyType TechnologyType { get; init; }

    /// <summary>
    /// Gets or sets the color depth of the display in bits.
    /// </summary>
    /// <remarks>
    /// DisplayColorDepthByBit represents the number of bits used by the display
    /// to define the color of a single pixel. Common color depths include 8, 16,
    /// 24, and 32 bits.
    /// </remarks>
    public int ColorDepthByBit { get; init; }
}