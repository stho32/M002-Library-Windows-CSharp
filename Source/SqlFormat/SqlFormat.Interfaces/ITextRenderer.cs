namespace SqlFormat.Interfaces;

public interface ITextRenderer
{
    ITextBlock Render();
}

public interface ITextBlock
{
    int Height { get; }
    int Width { get; }
    string Content { get; }
}

