using SqlFormat.Interfaces.TextPrimitives;

namespace SqlFormat.BL.TextPrimitives;

public class VerticalTextBlockGroup : TextBlockBase
{
    private readonly ITextBlock[] _blocks;

    public VerticalTextBlockGroup(
        int x, 
        int y, 
        ITextBlock[] blocks) : base(x, y)
    {
        _blocks = blocks;
    }

    protected override string[] GetContentInternal()
    {
        var alignment = new VerticalAlignment();
        var alignedBlocks = alignment.Align(X, Y, _blocks);
        var canvas = new TextCanvas();
        return canvas.Render(alignedBlocks);
    }
}