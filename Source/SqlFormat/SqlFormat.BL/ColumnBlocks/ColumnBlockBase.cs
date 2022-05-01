using SqlFormat.Interfaces;

namespace SqlFormat.BL.ColumnBlocks;

public abstract class ColumnBlockBase : ITextRenderer
{
    protected readonly string[] Columns;

    protected ColumnBlockBase(string[] columns)
    {
        Columns = columns;
    }

    public abstract ITextBlock Render();
}

public class TextBlock : ITextBlock
{
    public int Height { get; }
    public int Width { get; }
    public string Content { get; }

    public TextBlock(int height, int width, string content)
    {
        Height = height;
        Width = width;
        Content = content;
    }
}