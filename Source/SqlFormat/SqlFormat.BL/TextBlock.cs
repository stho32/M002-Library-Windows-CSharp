using SqlFormat.Interfaces;

namespace SqlFormat.BL;

public class TextBlock : ITextBlock
{
    public int X { get; }
    public int Y { get; }
    public int Width { get; }
    public int Height { get; }
    public string[] Content { get; }

    public TextBlock(int x, int y, string[] content)
    {
        X = x;
        Y = y;
        Content = content;
        Height = content.Length;
        Width = WidthOfTheLongestRow(content);
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
}