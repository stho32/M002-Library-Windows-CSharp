using SqlFormat.BL.TextPrimitives;
using SqlFormat.BL.TextPrimitives.Alignments;
using SqlFormat.Interfaces;
using SqlFormat.Interfaces.TextPrimitives;

namespace SqlFormat.BL.Sql;

public class DeclareSqlStatement : IStatement
{
    private readonly string _name;
    private readonly string _type;
    private readonly string? _defaultValue;

    public DeclareSqlStatement(string name, string type, string? defaultValue = null)
    {
        _name = name;
        _type = type;
        _defaultValue = defaultValue;
    }

    public ITextBlock[] Render()
    {
        var result = new List<ITextBlock>();

        result.Add(new TextBlock(0, 0, new[] {"DECLARE"}));
        result.Add(new TextBlock(0, 0, new[] {" "}));
        result.Add(new TextBlock(0, 0, new[] {_name}));
        result.Add(new TextBlock(0, 0, new[] {" "}));
        result.Add(new TextBlock(0, 0, new[] {_type}, new TagCollection(new []{"DECLARE_TYPE"})));
        
        if (_defaultValue != null)
        {
            result.Add(new TextBlock(0, 0, new[] {" = "}, new TagCollection(new []{"DECLARE_EQUALS"})));
            result.Add(new TextBlock(0, 0, new[] {_defaultValue}));
        }

        return new ITextBlock[]
        {
            new HorizontalTextBlockGroup(0, 0, result.ToArray())
        };
    }
}