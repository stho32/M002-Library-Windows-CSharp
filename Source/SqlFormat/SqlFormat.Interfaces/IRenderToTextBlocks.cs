using SqlFormat.Interfaces.TextPrimitives;

namespace SqlFormat.Interfaces;

public interface IRenderToTextBlocks
{
    ITextBlock[] Render();
}