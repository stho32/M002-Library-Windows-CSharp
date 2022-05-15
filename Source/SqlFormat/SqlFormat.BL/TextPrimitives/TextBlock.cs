using SqlFormat.Interfaces.TextPrimitives;

namespace SqlFormat.BL.TextPrimitives;

public class TextBlock : TextBlockBase
{
    public TextBlock(int x, int y, string[] content, 
        ITagCollection? tagCollection = null) :
        base(x, y, tagCollection)
    {
        Content = content;
    }

    protected override string[] GetContentInternal()
    {
        return Content;
    }
}