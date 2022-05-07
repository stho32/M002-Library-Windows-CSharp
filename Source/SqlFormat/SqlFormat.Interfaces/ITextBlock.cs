namespace SqlFormat.Interfaces;

/// <summary>
/// TextBlocks are drawn onto the TextCanvas
/// </summary>
public interface ITextBlock
{
    int X { get; }
    int Y { get; }
    int Width { get; }
    int Height { get; }
    string[] Content { get; }
}