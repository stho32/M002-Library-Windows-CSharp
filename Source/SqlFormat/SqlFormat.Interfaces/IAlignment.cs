using SqlFormat.Interfaces.TextPrimitives;

namespace SqlFormat.Interfaces;

public interface IAlignment
{
    ITextBlock[] Align(int x, int y, ITextBlock[] textBlocks);
}