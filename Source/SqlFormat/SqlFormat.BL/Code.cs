using SqlFormat.BL.TextPrimitives;
using SqlFormat.Interfaces;
using SqlFormat.Interfaces.TextPrimitives;

namespace SqlFormat.BL;

public class Code
{
    private readonly List<IStatement> _content = new();

    public void Add(IStatement statement)
    {
        _content.Add(statement);
    }

    public string[] Render()
    {
        var blocks = new List<ITextBlock>();
        foreach (var item in _content)
        {
            blocks.AddRange(item.Render());
        }
        
        var verticalGroup = new VerticalTextBlockGroup(0, 0, blocks.ToArray());
        var canvas = new TextCanvas();
        return canvas.Render(new ITextBlock[] {verticalGroup});
    }
}