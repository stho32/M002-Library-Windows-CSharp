using SqlFormat.Interfaces.TextPrimitives;

namespace SqlFormat.BL.TextPrimitives.Alignments;

public class HorizontalTextBlockGroup : TextBlockBase
{
    private readonly ITextBlock[] _blocks;

    public HorizontalTextBlockGroup(
        int x, 
        int y, 
        ITextBlock[] blocks) : base(x, y)
    {
        _blocks = blocks;
    }

    protected override string[] GetContentInternal()
    {
        var alignment = new HorizontalAlignment();
        var alignedBlocks = alignment.Align(X, Y, _blocks);
        var canvas = new TextCanvas();
        return canvas.Render(alignedBlocks);
    }
}