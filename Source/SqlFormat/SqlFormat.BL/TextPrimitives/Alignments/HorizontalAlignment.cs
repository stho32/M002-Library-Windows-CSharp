using SqlFormat.Interfaces;
using SqlFormat.Interfaces.TextPrimitives;

namespace SqlFormat.BL.TextPrimitives.Alignments;

public class HorizontalAlignment : IAlignment
{
    public ITextBlock[] Align(int x, int y, ITextBlock[] textBlocks)
    {
        var positionX = x;
        var result = new List<ITextBlock>();

        foreach (var sourceBlock in textBlocks)
        {
            var newBlock = new TextBlock(positionX, y, sourceBlock.GetContent(), sourceBlock.Tags);
            result.Add(newBlock);
            positionX += newBlock.GetWidth();
        }

        return result.ToArray();
    }
}