using SqlFormat.Interfaces.TextPrimitives;

namespace SqlFormat.Interfaces;

public interface IStatement
{
    ITextBlock[] Render();
}