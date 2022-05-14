namespace SqlFormat.BL.TextPrimitives;

public class TextBlock : TextBlockBase
{
    public TextBlock(int x, int y, string[] content) :
        base(x, y)
    {
        Content = content;
    }

    protected override string[] GetContentInternal()
    {
        return Content;
    }
}