using SqlFormat.Interfaces.TextPrimitives;

namespace SqlFormat.BL.TextPrimitives;

public abstract class TextBlockBase : ITextBlock
{
    public int X { get; }
    public int Y { get; }

    protected string[] Content = {};

    protected TextBlockBase(int x, int y)
    {
        X = x;
        Y = y;
    }
    public int GetWidth()
    {
        return WidthOfTheLongestRow(GetContent());
    }
    
    private int WidthOfTheLongestRow(string[] content)
    {
        var maximalLength = 0;
        
        foreach (var row in content)
        {
            if (row.Length > maximalLength)
                maximalLength = row.Length;
        }

        return maximalLength;
    }

    public int GetHeight()
    {
        var content = GetContent();
        return content.Length;
    }

    public string[] GetContent()
    {
        if (Content.Length == 0)
        {
            Content = GetContentInternal();
        }

        return Content;
    }

    protected abstract string[] GetContentInternal();
}