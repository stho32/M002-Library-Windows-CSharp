using SqlFormat.Interfaces;
using SqlFormat.Interfaces.TextPrimitives;

namespace SqlFormat.BL.TextPrimitives.Alignments;

public class VerticalAlignment : IAlignment
{
    public ITextBlock[] Align(int x, int y, ITextBlock[] textBlocks)
    {
        var positionY = y;
        var result = new List<ITextBlock>();

        foreach (var sourceBlock in textBlocks)
        {
            var newBlock = new TextBlock(x, positionY, sourceBlock.GetContent());
            result.Add(newBlock);
            positionY += newBlock.GetHeight();
        }

        return result.ToArray();
    }
}